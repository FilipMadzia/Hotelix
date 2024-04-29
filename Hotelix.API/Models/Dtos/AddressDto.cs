using System.Text.Json.Serialization;

namespace Hotelix.API.Models.Dtos;

public class AddressDto
{
	[JsonPropertyName("id")]
	public required Guid Id { get; set; }
	[JsonPropertyName("city")]
	public required CityDto City { get; set; }
	[JsonPropertyName("street")]
	public required string Street { get; set; }
	[JsonPropertyName("houseNumber")]
	public required int HouseNumber { get; set; }
	[JsonPropertyName("postalCode")]
	public required string PostalCode { get; set; }
}
