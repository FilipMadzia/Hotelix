namespace Hotelix.Mobile.Models;

public class Address
{
	public required int Id { get; set; }
	public required string Street { get; set; }
	public required int HouseNumber { get; set; }
	public required string PostalCode { get; set; }
	public required City City { get; set; }
}
