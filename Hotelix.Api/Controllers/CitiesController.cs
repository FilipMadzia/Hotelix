using Hotelix.Api.Data.Entities;
using Hotelix.Api.Models;
using Hotelix.Api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hotelix.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CitiesController(CityRepository _cityRepository) : ControllerBase
{
	// GET: api/Cities
	[AllowAnonymous]
	[HttpGet]
	[SwaggerResponse(200, type: typeof(IEnumerable<CityGet>))]
	public async Task<IActionResult> Get()
	{
		var cityEntities = await _cityRepository.GetAllAsync();

		var cities = cityEntities
			.Select(x => new CityGet
			{
				Id = x.Id,
				Name = x.Name
			});

		return Ok(cities);
	}

	// GET: api/Cities/1
	[AllowAnonymous]
	[HttpGet("{id}")]
	[SwaggerResponse(200, type: typeof(CityGet))]
	[SwaggerResponse(404)]
	public async Task<IActionResult> Get(int id)
	{
		var cityEntity = await _cityRepository.GetAsync(id);

		if(cityEntity == null) return NotFound();

		var city = new CityGet
		{
			Id = cityEntity.Id,
			Name = cityEntity.Name
		};


		return Ok(city);
	}

	// POST: api/Cities
	[HttpPost]
	[SwaggerResponse(201)]
	[SwaggerResponse(401)]
	public async Task<IActionResult> Post([FromBody] CityPost city)
	{
		var cityEntity = new CityEntity { Name = city.Name };

		await _cityRepository.AddAsync(cityEntity);
		await _cityRepository.SaveChangesAsync();

		return CreatedAtAction(nameof(Get), new { cityEntity.Id }, new CityGet { Id = cityEntity.Id, Name = cityEntity.Name });
	}

	// PUT: api/Cities/1
	[HttpPut("{id}")]
	[SwaggerResponse(204)]
	[SwaggerResponse(401)]
	[SwaggerResponse(404)]
	public async Task<IActionResult> Put(int id, [FromBody] CityPut city)
	{
		var cityEntity = await _cityRepository.GetAsync(id);

		if(cityEntity == null) return NotFound();

		cityEntity.Name = city.Name;

		_cityRepository.Update(cityEntity);
		await _cityRepository.SaveChangesAsync();

		return NoContent();
	}

	// DELETE: api/Cities/1
	[HttpDelete("{id}")]
	[SwaggerResponse(204)]
	[SwaggerResponse(401)]
	[SwaggerResponse(404)]
	public async Task<IActionResult> Delete(int id)
	{
		var cityEntity = await _cityRepository.GetAsync(id);

		if(cityEntity == null) return NotFound();

		_cityRepository.SoftDelete(cityEntity);
		await _cityRepository.SaveChangesAsync();

		return NoContent();
	}
}
