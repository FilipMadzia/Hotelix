namespace Hotelix.API.Data.Entities;

public class CityEntity : BaseEntity
{
	public required string Name { get; set; }

	public ICollection<AddressEntity>? Addresses { get; set; }
}
