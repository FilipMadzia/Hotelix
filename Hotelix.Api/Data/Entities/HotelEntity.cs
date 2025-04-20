using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.Api.Data.Entities;

public class HotelEntity : Entity
{
	[MaxLength(64)]
	public required string Name { get; set; }
	[MaxLength(512)]
	public string? Description { get; set; }
	[Precision(10, 2)]
	public decimal PricePerNight { get; set; }

	public AddressEntity Address { get; set; }
	public ContactEntity Contact { get; set; }
}
