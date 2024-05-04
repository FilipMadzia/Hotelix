using Hotelix.API.Data.Entities;
using Hotelix.API.Models;
using Hotelix.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hotelix.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitiesController(CityRepository _cityRepository) : ControllerBase
{
	// GET: api/Cities
	[HttpGet]
	[SwaggerResponse(200, type: typeof(IEnumerable<CityGet>))]
	public async Task<IActionResult> Get()
	{
		var entities = await _cityRepository.GetAllAsync();

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
		var entity = await _cityRepository.GetAsync(id);

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

		await _cityRepository.AddAsync(entity);
		await _cityRepository.SaveChangesAsync();

		return Created(entity.Id.ToString(), city);
	}

	// PUT: api/Cities/1
	[HttpPut("{id}")]
	[SwaggerResponse(204)]
	[SwaggerResponse(404)]
	public async Task<IActionResult> Put(int id, [FromBody] CityPut city)
	{
		var entity = await _cityRepository.GetAsync(id);

		if(entity == null) return NotFound();

		entity.Name = city.Name;

		_cityRepository.Update(entity);
		await _cityRepository.SaveChangesAsync();

		return NoContent();
	}

	// DELETE: api/Cities/1
	[HttpDelete("{id}")]
	[SwaggerResponse(204)]
	[SwaggerResponse(404)]
	public async Task<IActionResult> Delete(int id)
	{
		var entity = await _cityRepository.GetAsync(id);

		if(entity == null) return NotFound();

		_cityRepository.SoftDelete(entity);
		await _cityRepository.SaveChangesAsync();

		return NoContent();
	}
}
