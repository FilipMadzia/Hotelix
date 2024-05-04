using Hotelix.API.Models;
using Hotelix.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hotelix.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelsController(HotelRepository hotelRepository, AddressRepository addressRepository) : ControllerBase
{
	readonly HotelRepository _hotelRepository = hotelRepository;
	readonly AddressRepository _addressRepository = addressRepository;

	// GET: api/Hotels
	[HttpGet]
	[SwaggerResponse(200, type: typeof(IEnumerable<HotelGet>))]
	public async Task<IActionResult> Get()
	{
		var entities = await _hotelRepository.GetAllAsync();

		var hotels = entities.Select(x => new HotelGet
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
		var entity = await _hotelRepository.GetAsync(id);

		if(entity == null) return NotFound();

		var hotel = new HotelGet
		{
			Id = entity.Id,
			Name = entity.Name,
			Description = entity.Description,
			Address = new AddressGet
			{
				Id = entity.Address.Id,
				Street = entity.Address.Street,
				HouseNumber = entity.Address.HouseNumber,
				PostalCode = entity.Address.PostalCode,
				City = new CityGet
				{
					Id = entity.Address.CityId,
					Name = entity.Address.City.Name
				}
			}
		};

		return Ok(hotel);
	}
}
