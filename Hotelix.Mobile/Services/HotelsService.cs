using Hotelix.Mobile.Models;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Text.Json;

namespace Hotelix.Mobile.Services;

public class HotelsService(IConfiguration _configuration)
{
	HttpClient _client = new();
	JsonSerializerOptions _serializerOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
		WriteIndented = true
	};
	Uri apiUrl = new(_configuration.GetRequiredSection("urls").Get<Urls>().ApiUrl);
	Uri coverImagesUrl = new(_configuration.GetRequiredSection("urls").Get<Urls>().CoverImagesUrl);

	public async Task<List<Hotel>> GetHotelsAsync()
	{
		var hotels = new List<Hotel>();

		try
		{
			var response = await _client.GetAsync(apiUrl + "Hotels");

			if(response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();

				hotels = JsonSerializer.Deserialize<List<Hotel>>(content, _serializerOptions) ?? new List<Hotel>();
			}
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex);
		}

		foreach(var hotel in hotels)
		{
			hotel.CoverImage = coverImagesUrl + hotel.CoverImage;
		}

		return hotels;
	}

	public async Task<Hotel> GetHotelAsync(int id)
	{
		var hotel = new Hotel();

		try
		{
			var response = await _client.GetAsync(apiUrl + "/Hotels/" + id);

			if(response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();

				hotel = JsonSerializer.Deserialize<Hotel>(content, _serializerOptions) ?? new Hotel();
			}
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex);
		}

		hotel.CoverImage = coverImagesUrl + hotel.CoverImage;

		return hotel;
	}
}
