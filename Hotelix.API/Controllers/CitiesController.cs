using Microsoft.AspNetCore.Mvc;
using Hotelix.API.Repositories;
using Hotelix.API.Models;
using Swashbuckle.AspNetCore.Annotations;
using Hotelix.API.Data.Entities;

namespace Hotelix.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitiesController(CityRepository _repository) : ControllerBase
{
    // GET: api/Cities
    [HttpGet]
    [SwaggerResponse(200, type: typeof(IEnumerable<CityGet>))]
    public async Task<IActionResult> Get()
    {
        var entities = await _repository.GetAllAsync();

        var cities = entities
            .Select(x => new CityGet
            {
                Id = x.Id,
                Name = x.Name
            });

		return Ok(cities);
    }

	// GET: api/Cities/1
	[HttpGet("{id}")]
    [SwaggerResponse(200, type: typeof(CityGet))]
    [SwaggerResponse(404)]
	public async Task<IActionResult> Get(int id)
    {
        var entity = await _repository.GetAsync(id);

		if(entity == null) return NotFound();

		var city = new CityGet
        {
            Id = entity.Id,
            Name = entity.Name
        };


		return Ok(city);
    }

    // POST: api/Cities
    [HttpPost]
    [SwaggerResponse(201)]
    public async Task<IActionResult> Post([FromBody] CityPost city)
    {
        var entity = new CityEntity { Name = city.Name };

        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return Created(entity.Id.ToString(), city);
    }

    // PUT: api/Cities/1
    [HttpPut("{id}")]
    [SwaggerResponse(204)]
    [SwaggerResponse(404)]
    public async Task<IActionResult> Put(int id, [FromBody] CityPut city)
    {
        var entity = await _repository.GetAsync(id);

        if(entity == null) return NotFound();

        entity.Name = city.Name;

        _repository.Update(entity);
        await _repository.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Cities/1
    [HttpDelete("{id}")]
    [SwaggerResponse(204)]
    [SwaggerResponse(404)]
	public async Task<IActionResult> Delete(int id)
    {
        var entity = await _repository.GetAsync(id);

        if(entity == null) return NotFound();

		_repository.SoftDelete(entity);
		await _repository.SaveChangesAsync();

        return NoContent();
    }
}
