namespace Hotelix.API.Data.Entities;

public class ContactEntity : BaseEntity
{
	public string? PhoneNumber { get; set; }
	public string? Email { get; set; }

	public int HotelId { get; set; }
	public HotelEntity Hotel { get; set; } = null!;
}
