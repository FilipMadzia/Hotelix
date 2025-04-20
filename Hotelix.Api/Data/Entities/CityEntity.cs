using System.ComponentModel.DataAnnotations;

namespace Hotelix.Api.Data.Entities;

public class CityEntity : Entity
{
	[MaxLength(128)]
	public required string Name { get; set; }

	public ICollection<AddressEntity>? Addresses { get; set; }
}
