namespace Hotelix.API.Models;

public class AddressGet
{
	public required int Id { get; set; }
	public required CityGet City { get; set; }
	public required string Street { get; set; }
	public required int HouseNumber { get; set; }
	public required string PostalCode { get; set; }
}

public class AddressPost
{
	public required int CityId { get; set; }
	public required string Street { get; set; }
	public required int HouseNumber { get; set; }
	public required string PostalCode { get; set; }
}

public class AddressPut
{
	public required int CityId { get; set; }
	public required string Street { get; set; }
	public required int HouseNumber { get; set; }
	public required string PostalCode { get; set; }
}
