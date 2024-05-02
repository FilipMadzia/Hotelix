namespace Hotelix.API.Data.Entities;

public class CityEntity : BaseEntity
{
	public required string Name { get; set; }

	public virtual ICollection<AddressEntity>? Addresses { get; set; }
}
