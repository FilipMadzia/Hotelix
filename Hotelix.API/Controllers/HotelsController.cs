using Hotelix.API.Data.Entities;
using Hotelix.API.Models;
using Hotelix.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hotelix.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelsController(HotelRepository hotelRepository, AddressRepository addressRepository, CityRepository cityRepository) : ControllerBase
{
	readonly HotelRepository _hotelRepository = hotelRepository;
	readonly AddressRepository _addressRepository = addressRepository;
	readonly CityRepository _cityRepository = cityRepository;

	// GET: api/Hotels
	[HttpGet]
	[SwaggerResponse(200, type: typeof(IEnumerable<HotelGet>))]
	public async Task<IActionResult> Get()
	{
		var hotelEntities = await _hotelRepository.GetAllAsync();

		var hotels = hotelEntities.Select(x => new HotelGet
		{
			Id = x.Id,
			Name = x.Name,
			Description = x.Description,
			Address = new AddressGet
			{
				Id = x.Address.Id,
				Street = x.Address.Street,
				HouseNumber = x.Address.HouseNumber,
				PostalCode = x.Address.PostalCode,
				City = new CityGet
				{
					Id = x.Address.CityId,
					Name = x.Address.City.Name
				}
			}
		});

		return Ok(hotels);
	}

	// GET: api/Hotels/1
	[HttpGet("{id}")]
	[SwaggerResponse(200, type: typeof(HotelGet))]
	[SwaggerResponse(404)]
	public async Task<IActionResult> Get(int id)
	{
		var hotelEntity = await _hotelRepository.GetAsync(id);

		if(hotelEntity == null) return NotFound();

		var hotel = new HotelGet
		{
			Id = hotelEntity.Id,
			Name = hotelEntity.Name,
			Description = hotelEntity.Description,
			Address = new AddressGet
			{
				Id = hotelEntity.Address.Id,
				Street = hotelEntity.Address.Street,
				HouseNumber = hotelEntity.Address.HouseNumber,
				PostalCode = hotelEntity.Address.PostalCode,
				City = new CityGet
				{
					Id = hotelEntity.Address.CityId,
					Name = hotelEntity.Address.City.Name
				}
			}
		};

		return Ok(hotel);
	}

	// POST: api/Hotels
	[HttpPost]
	[SwaggerResponse(201)]
	[SwaggerResponse(404)]
	public async Task<IActionResult> Post([FromBody] HotelPost hotel)
	{
		var cityEntity = await _cityRepository.GetAsync(hotel.Address.CityId);

		if(cityEntity == null) return NotFound();

		var hotelEntity = new HotelEntity
		{
			Name = hotel.Name,
			Description = hotel.Description
		};

		await _hotelRepository.AddAsync(hotelEntity);
		await _hotelRepository.SaveChangesAsync();

		var addressEntity = new AddressEntity
		{
			Street = hotel.Address.Street,
			HouseNumber = hotel.Address.HouseNumber,
			PostalCode = hotel.Address.PostalCode,
			City = cityEntity,
			HotelId = hotelEntity.Id
		};

		await _addressRepository.AddAsync(addressEntity);
		await _addressRepository.SaveChangesAsync();

		return CreatedAtAction(hotelEntity.Id.ToString(), hotel);
	}

	// PUT: api/Hotels/1
	[HttpPut("{id}")]
	[SwaggerResponse(204)]
	[SwaggerResponse(404)]
	public async Task<IActionResult> Put(int id, [FromBody] HotelPut hotel)
	{
		var hotelEntity = await _hotelRepository.GetAsync(id);
		var addressEntity = await _addressRepository.GetAsync(id);
		var cityEntity = await _cityRepository.GetAsync(hotel.Address.CityId);

		if(hotelEntity == null || addressEntity == null || cityEntity == null) return NotFound();

		hotelEntity.Name = hotel.Name;
		hotelEntity.Description = hotel.Description;

		_hotelRepository.Update(hotelEntity);
		await _hotelRepository.SaveChangesAsync();

		addressEntity.Street = hotel.Address.Street;
		addressEntity.HouseNumber = hotel.Address.HouseNumber;
		addressEntity.PostalCode = hotel.Address.PostalCode;
		addressEntity.CityId = hotel.Address.CityId;
		addressEntity.HotelId = hotelEntity.Id;

		_addressRepository.Update(addressEntity);
		await _addressRepository.SaveChangesAsync();

		return NoContent();
	}

	// DELETE: api/Hotels/1
	[HttpDelete]
	[SwaggerResponse(204)]
	[SwaggerResponse(404)]
	public async Task<IActionResult> Delete(int id)
	{
		var hotelEntity = await _hotelRepository.GetAsync(id);

		if(hotelEntity == null) return NotFound();

		_hotelRepository.SoftDelete(hotelEntity);
		await _hotelRepository.SaveChangesAsync();

		return NoContent();
	}
}
