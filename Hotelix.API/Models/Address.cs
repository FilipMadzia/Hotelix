namespace Hotelix.Api.Models;

public class AddressGet
{
	public required int Id { get; set; }
	public required string Street { get; set; }
	public required int HouseNumber { get; set; }
	public required string PostalCode { get; set; }
	public required CityGet City { get; set; }
}

public class AddressPost
{
	public required string Street { get; set; }
	public required int HouseNumber { get; set; }
	public required string PostalCode { get; set; }
	public required int CityId { get; set; }
}

public class AddressPut
{
	public required string Street { get; set; }
	public required int HouseNumber { get; set; }
	public required string PostalCode { get; set; }
	public required int CityId { get; set; }
}
