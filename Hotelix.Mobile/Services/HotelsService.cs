using Hotelix.Mobile.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Hotelix.Mobile.Services;

public static class HotelsService
{
	static HttpClient _client = new();
	static JsonSerializerOptions _serializerOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
		WriteIndented = true
	};
	static Uri uri = new("http://192.168.100.6:5000/api/Hotels");

	public static async Task<List<Hotel>> GetHotelsAsync()
	{
		try
		{
			var response = await _client.GetAsync(uri);

			if(response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();

				return JsonSerializer.Deserialize<List<Hotel>>(content, _serializerOptions) ?? new List<Hotel>();
			}
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex);
		}

		return new List<Hotel>();
	}

	public static async Task<Hotel> GetHotelAsync(int id)
	{
		try
		{
			var response = await _client.GetAsync(uri + "/" + id);

			if(response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();

				return JsonSerializer.Deserialize<Hotel>(content, _serializerOptions) ?? new Hotel();
			}
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex);
		}

		return new Hotel();
	}
}
