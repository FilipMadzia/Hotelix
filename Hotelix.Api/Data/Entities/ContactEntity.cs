using System.ComponentModel.DataAnnotations;

namespace Hotelix.Api.Data.Entities;

public class ContactEntity : Entity
{
	[MaxLength(9)]
	public string? PhoneNumber { get; set; }
	[MaxLength(254)]
	public string? Email { get; set; }

	public Guid HotelId { get; set; }
	public HotelEntity Hotel { get; set; }
}
