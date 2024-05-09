using Hotelix.API.Models;
using Hotelix.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hotelix.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AddressesController(AddressRepository addressRepository) : ControllerBase
{
	readonly AddressRepository _addressRepository = addressRepository;

	// GET: api/Addresses
	[HttpGet]
	[SwaggerResponse(200, type: typeof(IEnumerable<AddressGet>))]
	public async Task<IActionResult> Get()
	{
		var addressEntities = await _addressRepository.GetAllAsync();

		var addresses = addressEntities
			.Select(x => new AddressGet
			{
				Id = x.Id,
				Street = x.Street,
				HouseNumber = x.HouseNumber,
				PostalCode = x.PostalCode,
				City = new CityGet
				{
					Id = x.City.Id,
					Name = x.City.Name
				}
			});

		return Ok(addresses);
	}

	// GET: api/Addresses/1
	[HttpGet("{id}")]
	[SwaggerResponse(200, type: typeof(AddressGet))]
	[SwaggerResponse(404)]
	public async Task<IActionResult> Get(int id)
	{
		var addressEntity = await _addressRepository.GetAsync(id);

		if(addressEntity == null) return NotFound();

		var address = new AddressGet
		{
			Id = addressEntity.Id,
			Street = addressEntity.Street,
			HouseNumber = addressEntity.HouseNumber,
			PostalCode = addressEntity.PostalCode,
			City = new CityGet
			{
				Id = addressEntity.City.Id,
				Name = addressEntity.City.Name
			}
		};

		return Ok(address);
	}
}
