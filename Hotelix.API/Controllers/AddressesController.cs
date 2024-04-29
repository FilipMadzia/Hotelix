using Hotelix.API.Models.Dtos;
using Hotelix.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hotelix.API.Controllers;

[Route("api/[controller]/[Action]")]
[ApiController]
public class AddressesController(AddressRepository _repository) : ControllerBase
{
	// GET: api/Addresses/GetAll
	[HttpGet]
	[SwaggerResponse(200, type: typeof(IEnumerable<AddressDto>))]
	public async Task<IActionResult> GetAll()
	{
		var entities = await _repository.GetAllAsync();

		var dtos = entities
			.Select(x => new AddressDto
			{
				Id = x.Id,
				City = new CityDto
				{
					Id = x.City.Id,
					Name = x.City.Name
				},
				Street = x.Street,
				HouseNumber = x.HouseNumber,
				PostalCode = x.PostalCode
			});

		return Ok(dtos);
	}

	// GET: api/Addresses/Get/51373a42-1d63-4277-b0af-1cbc21a08cf5
	[HttpGet("{id}")]
	[SwaggerResponse(200, type: typeof(AddressDto))]
	[SwaggerResponse(400)]
	public async Task<IActionResult> Get(Guid id)
	{
		var entity = await _repository.GetAsync(id);

		if(entity == null) return NotFound();

		var dto = new AddressDto
		{
			Id = entity.Id,
			City = new CityDto
			{
				Id = entity.City.Id,
				Name = entity.City.Name
			},
			Street = entity.Street,
			HouseNumber = entity.HouseNumber,
			PostalCode = entity.PostalCode
		};

		return Ok(dto);
	}
}
