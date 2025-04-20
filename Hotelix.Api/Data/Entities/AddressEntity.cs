using System.ComponentModel.DataAnnotations;

namespace Hotelix.Api.Data.Entities;

public class AddressEntity : Entity
{
	[MaxLength(128)]
	public required string Street { get; set; }
	public int HouseNumber { get; set; }
	[MaxLength(6)]
	public required string PostalCode { get; set; }

	public int CityId { get; set; }
	public CityEntity City { get; set; }

	public int HotelId { get; set; }
	public HotelEntity Hotel { get; set; }
}
