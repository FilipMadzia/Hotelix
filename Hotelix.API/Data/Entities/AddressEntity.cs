namespace Hotelix.API.Data.Entities;

public class AddressEntity : BaseEntity
{
	public required int CityId { get; set; }
	public CityEntity City { get; set; } = null!;
	public required string Street { get; set; }
	public required int HouseNumber { get; set; }
	public required string PostalCode { get; set; }
}
