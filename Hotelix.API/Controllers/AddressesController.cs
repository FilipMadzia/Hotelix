using Hotelix.API.Data.Entities;
using Hotelix.API.Models;
using Hotelix.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hotelix.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressesController : ControllerBase
{
	readonly AddressRepository _repository;
	readonly CityRepository _cityRepository;

    public AddressesController(AddressRepository addressRepository, CityRepository cityRepository)
    {
        _repository = addressRepository;
		_cityRepository = cityRepository;
    }

	// GET: api/Addresses
	[HttpGet]
	[SwaggerResponse(200, type: typeof(IEnumerable<AddressGet>))]
	public async Task<IActionResult> Get()
	{
		var entities = await _repository.GetAllAsync();

		var addresses = entities
			.Select(x => new AddressGet
			{
				Id = x.Id,
				City = new CityGet
				{
					Id = x.City.Id,
					Name = x.City.Name
				},
				Street = x.Street,
				HouseNumber = x.HouseNumber,
				PostalCode = x.PostalCode
			});

		return Ok(addresses);
	}

	// GET: api/Addresses/1
	[HttpGet("{id}")]
	[SwaggerResponse(200, type: typeof(AddressGet))]
	[SwaggerResponse(400)]
	public async Task<IActionResult> Get(int id)
	{
		var entity = await _repository.GetAsync(id);

		if(entity == null) return NotFound();

		var address = new AddressGet
		{
			Id = entity.Id,
			City = new CityGet
			{
				Id = entity.City.Id,
				Name = entity.City.Name
			},
			Street = entity.Street,
			HouseNumber = entity.HouseNumber,
			PostalCode = entity.PostalCode
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
			CityId = cityEntity.Id,
			City = cityEntity,
			Street = address.Street,
			HouseNumber = address.HouseNumber,
			PostalCode = address.PostalCode
		};

		await _repository.AddAsync(entity);
		await _repository.SaveChangesAsync();

		return Created(entity.Id.ToString(), address);
	}

	// PUT: api/Addresses/1
	[HttpPut("{id}")]
	[SwaggerResponse(204)]
	[SwaggerResponse(404)]
	public async Task<IActionResult> Put(int id, [FromBody] AddressPut address)
	{
		var entity = await _repository.GetAsync(id);
		var cityEntity = await _cityRepository.GetAsync(address.CityId);

		if(entity == null || cityEntity == null) return NotFound();

		entity.CityId = cityEntity.Id;
		entity.City = cityEntity;
		entity.Street = address.Street;
		entity.HouseNumber = address.HouseNumber;
		entity.PostalCode = address.PostalCode;

		_repository.Update(entity);
		await _repository.SaveChangesAsync();

		return NoContent();
	}

	// DELETE: api/Addresses/1
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
