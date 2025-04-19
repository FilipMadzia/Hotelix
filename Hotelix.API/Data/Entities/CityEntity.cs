namespace Hotelix.Api.Data.Entities;

public class CityEntity : BaseEntity
{
	public required string Name { get; set; }

	public ICollection<AddressEntity>? Addresses { get; set; }

	public void Update(string name) => Name = name;
}
