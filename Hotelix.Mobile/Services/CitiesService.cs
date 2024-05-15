using Hotelix.Mobile.Models;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Text.Json;

namespace Hotelix.Mobile.Services;

class CitiesService(IConfiguration _configuration)
{
	HttpClient _client = new();
	JsonSerializerOptions _serializerOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
		WriteIndented = true
	};
	Uri apiUrl = new(_configuration.GetRequiredSection("urls").Get<Urls>().ApiUrl);

	public async Task<List<City>> GetCitiesAsync()
	{
		var cities = new List<City>();

		try
		{
			var response = await _client.GetAsync(apiUrl + "Cities");

			if(response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();

				cities = JsonSerializer.Deserialize<List<City>>(content, _serializerOptions) ?? new List<City>();
			}
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex);
		}

		return cities;
	}

	public async Task<City> GetCityAsync(int id)
	{
		var city = new City();

		try
		{
			var response = await _client.GetAsync(apiUrl + "/Hotels/" + id);

			if(response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();

				city = JsonSerializer.Deserialize<City>(content, _serializerOptions) ?? new City();
			}
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex);
		}

		return city;
	}
}
