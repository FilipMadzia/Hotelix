using Microsoft.AspNetCore.Mvc;
using Hotelix.API.Repositories;
using Hotelix.API.Models.Dtos;
using Swashbuckle.AspNetCore.Annotations;

namespace Hotelix.API.Controllers;

[Route("api/[controller]/[Action]")]
[ApiController]
public class CitiesController(CityRepository _repository) : ControllerBase
{
    // GET: api/Cities/GetAll
    [HttpGet]
    [SwaggerResponse(200, type: typeof(IEnumerable<CityDto>))]
    public async Task<IActionResult> GetAll()
    {
        var entities = await _repository.GetAllAsync();

        var dtos = entities
            .Select(x => new CityDto
            {
                Id = x.Id,
                Name = x.Name
            });

		return Ok(dtos);
    }

	// GET: api/Cities/Get/5
	[HttpGet("{id}")]
    [SwaggerResponse(200, type: typeof(CityDto))]
    [SwaggerResponse(404)]
	public async Task<IActionResult> Get(Guid id)
    {
        var entity = await _repository.GetAsync(id);

		if(entity == null)
        {
            return NotFound();
        }

        var dto = new CityDto
        {
            Id = entity.Id,
            Name = entity.Name
        };


		return Ok(dto);
    }
}
