namespace Hotelix.API.Data.Entities;

public class HotelEntity : BaseEntity
{
	public required string Name { get; set; }
	public string? Description { get; set; }

	public AddressEntity Address { get; set; } = null!;
	public ContactEntity Contact { get; set; } = null!;
}
