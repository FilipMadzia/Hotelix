using Hotelix.API.Data.Entities;
using Hotelix.API.Models;
using Hotelix.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hotelix.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressesController(AddressRepository addressRepository, CityRepository cityRepository) : ControllerBase
{
	readonly AddressRepository _addressRepository = addressRepository;
	readonly CityRepository _cityRepository = cityRepository;

	// GET: api/Addresses
	[HttpGet]
	[SwaggerResponse(200, type: typeof(IEnumerable<AddressGet>))]
	public async Task<IActionResult> Get()
	{
		var entities = await _addressRepository.GetAllAsync();

		var addresses = entities
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
		var entity = await _addressRepository.GetAsync(id);

		if(entity == null) return NotFound();

		var address = new AddressGet
		{
			Id = entity.Id,
			Street = entity.Street,
			HouseNumber = entity.HouseNumber,
			PostalCode = entity.PostalCode,
			City = new CityGet
			{
				Id = entity.City.Id,
				Name = entity.City.Name
			}
		};

		return Ok(address);
	}

	// POST: api/Addresses
	[HttpPost]
	[SwaggerResponse(201)]
	[SwaggerResponse(404)]
	public async Task<IActionResult> Post([FromBody] AddressPost address)
	{
		var cityEntity = await _cityRepository.GetAsync(address.CityId);

		if(cityEntity == null) return NotFound();

		var entity = new AddressEntity
		{
			Street = address.Street,
			HouseNumber = address.HouseNumber,
			PostalCode = address.PostalCode,
			CityId = cityEntity.Id,
			City = cityEntity
		};

		await _addressRepository.AddAsync(entity);
		await _addressRepository.SaveChangesAsync();

		return Created(entity.Id.ToString(), address);
	}

	// PUT: api/Addresses/1
	[HttpPut("{id}")]
	[SwaggerResponse(204)]
	[SwaggerResponse(404)]
	public async Task<IActionResult> Put(int id, [FromBody] AddressPut address)
	{
		var entity = await _addressRepository.GetAsync(id);
		var cityEntity = await _cityRepository.GetAsync(address.CityId);

		if(entity == null || cityEntity == null) return NotFound();

		entity.Street = address.Street;
		entity.HouseNumber = address.HouseNumber;
		entity.PostalCode = address.PostalCode;
		entity.CityId = cityEntity.Id;
		entity.City = cityEntity;

		_addressRepository.Update(entity);
		await _addressRepository.SaveChangesAsync();

		return NoContent();
	}

	// DELETE: api/Addresses/1
	[HttpDelete("{id}")]
	[SwaggerResponse(204)]
	[SwaggerResponse(404)]
	public async Task<IActionResult> Delete(int id)
	{
		var entity = await _addressRepository.GetAsync(id);

		if(entity == null) return NotFound();

		_addressRepository.SoftDelete(entity);
		await _addressRepository.SaveChangesAsync();

		return NoContent();
	}
}
