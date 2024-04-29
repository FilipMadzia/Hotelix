using System.ComponentModel.DataAnnotations.Schema;

namespace Hotelix.API.Data.Entities;

[Table("Addresses")]
public class AddressEntity : BaseEntity
{
	public required CityEntity City { get; set; }
	public required string Street { get; set; }
	public required int HouseNumber { get; set; }
	public required string PostalCode { get; set; }
}
