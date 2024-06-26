﻿using Hotelix.API.Data.Entities;
using Hotelix.API.Models;
using Hotelix.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Drawing;

namespace Hotelix.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class HotelsController(
	IWebHostEnvironment _environment,
	HotelRepository _hotelRepository,
	AddressRepository _addressRepository,
	CityRepository _cityRepository,
	ContactRepository _contactRepository) : ControllerBase
{
	// GET: api/Hotels
	[AllowAnonymous]
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
			PricePerNight = x.PricePerNight,
			HasInternet = x.HasInternet,
			HasTelevision = x.HasTelevision,
			HasParking = x.HasParking,
			HasCafeteria = x.HasCafeteria,
			CoverImage = $"Cover{x.Id}.png",
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
			},
			Contact = new ContactGet
			{
				Id = x.Contact.Id,
				PhoneNumber = x.Contact.PhoneNumber,
				Email = x.Contact.Email
			}
		});

		return Ok(hotels);
	}

	// GET: api/Hotels/1
	[AllowAnonymous]
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
			PricePerNight = hotelEntity.PricePerNight,
			HasInternet = hotelEntity.HasInternet,
			HasTelevision = hotelEntity.HasTelevision,
			HasParking = hotelEntity.HasParking,
			HasCafeteria = hotelEntity.HasCafeteria,
			CoverImage = $"Cover{hotelEntity.Id}.png",
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
			},
			Contact = new ContactGet
			{
				Id = hotelEntity.Contact.Id,
				PhoneNumber = hotelEntity.Contact.PhoneNumber,
				Email = hotelEntity.Contact.Email
			}
		};

		return Ok(hotel);
	}

	// POST: api/Hotels
	[HttpPost]
	[SwaggerResponse(201)]
	[SwaggerResponse(401)]
	[SwaggerResponse(404)]
	public async Task<IActionResult> Post([FromBody] HotelPost hotel)
	{
		var cityEntity = await _cityRepository.GetAsync(hotel.Address.CityId);

		if(cityEntity == null) return NotFound();

		var hotelEntity = new HotelEntity
		{
			Name = hotel.Name,
			Description = hotel.Description,
			PricePerNight = hotel.PricePerNight,
			HasInternet = hotel.HasInternet,
			HasTelevision = hotel.HasTelevision,
			HasParking = hotel.HasParking,
			HasCafeteria = hotel.HasCafeteria
		};

		await _hotelRepository.AddAsync(hotelEntity);
		await _hotelRepository.SaveChangesAsync();

		using(var ms = new MemoryStream(hotel.CoverImage))
		{
			var coverImage = Image.FromStream(ms);
			coverImage.Save(Path.Combine(_environment.WebRootPath, "Images", "Covers", $"Cover{hotelEntity.Id}.png"));
		}

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

		var contactEntity = new ContactEntity
		{
			PhoneNumber = hotel.Contact.PhoneNumber,
			Email = hotel.Contact.Email,
			HotelId = hotelEntity.Id
		};

		await _contactRepository.AddAsync(contactEntity);
		await _contactRepository.SaveChangesAsync();

		return CreatedAtAction(nameof(Get), new { hotelEntity.Id }, new HotelGet
		{
			Id = hotelEntity.Id,
			Name = hotelEntity.Name,
			Description = hotelEntity.Description,
			PricePerNight = hotelEntity.PricePerNight,
			HasInternet = hotelEntity.HasInternet,
			HasTelevision = hotelEntity.HasTelevision,
			HasParking = hotelEntity.HasParking,
			HasCafeteria = hotelEntity.HasCafeteria,
			CoverImage = $"Cover{hotelEntity.Id}.png",
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
			},
			Contact = new ContactGet
			{
				Id = hotelEntity.Contact.Id,
				PhoneNumber = hotelEntity.Contact.PhoneNumber,
				Email = hotelEntity.Contact.Email
			}
		});
	}

	// PUT: api/Hotels/1
	[HttpPut("{id}")]
	[SwaggerResponse(204)]
	[SwaggerResponse(401)]
	[SwaggerResponse(404)]
	public async Task<IActionResult> Put(int id, [FromBody] HotelPut hotel)
	{
		var hotelEntity = await _hotelRepository.GetAsync(id);
		var addressEntity = await _addressRepository.GetAsync(id);
		var cityEntity = await _cityRepository.GetAsync(hotel.Address.CityId);
		var contactEntity = await _contactRepository.GetAsync(id);

		if(hotelEntity == null || addressEntity == null || cityEntity == null || contactEntity == null) return NotFound();

		using(var ms = new MemoryStream(hotel.CoverImage))
		{
			var coverImage = Image.FromStream(ms);
			coverImage.Save(Path.Combine(_environment.WebRootPath, "Images", "Covers", $"Cover{hotelEntity.Id}.png"));
		}

		#region Update HotelEntity

		hotelEntity.Update(
			hotel.Name,
			hotel.Description,
			hotel.PricePerNight,
			hotel.HasInternet,
			hotel.HasTelevision,
			hotel.HasParking,
			hotel.HasCafeteria);

		_hotelRepository.Update(hotelEntity);
		await _hotelRepository.SaveChangesAsync();

		#endregion

		#region Update AddressEntity

		var address = hotel.Address;

		addressEntity.Update(
			address.Street,
			address.HouseNumber,
			address.PostalCode,
			address.CityId,
			hotelEntity.Id
			);

		_addressRepository.Update(addressEntity);
		await _addressRepository.SaveChangesAsync();

		#endregion

		#region Update ContactEntity

		var contact = hotel.Contact;

		contactEntity.Update(
			contact.PhoneNumber,
			contact.Email,
			hotelEntity.Id);

		_contactRepository.Update(contactEntity);
		await _contactRepository.SaveChangesAsync();

		#endregion

		return NoContent();
	}

	// DELETE: api/Hotels/1
	[HttpDelete("{id}")]
	[SwaggerResponse(204)]
	[SwaggerResponse(401)]
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
