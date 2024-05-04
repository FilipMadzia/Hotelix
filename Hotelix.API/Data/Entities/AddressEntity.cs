namespace Hotelix.API.Data.Entities;

public class AddressEntity : BaseEntity
{
	public required string Street { get; set; }
	public int HouseNumber { get; set; }
	public required string PostalCode { get; set; }

	public int CityId { get; set; }
	public CityEntity City { get; set; } = null!;

	public int HotelId { get; set; }
	public HotelEntity Hotel { get; set; } = null!;
}
