using System.Text.Json.Serialization;

namespace Hotelix.API.Models.Dtos;

public class CityDto
{
	[JsonPropertyName("id")]
	public required Guid Id { get; set; }
	[JsonPropertyName("name")]
	public required string Name { get; set; }
}
