using Hotelix.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.Api.Data.Seeders;

public class ContactsSeeder
{
	public static void Seed(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ContactEntity>().HasData(new List<ContactEntity>
		{
			new() { Id = 1, HotelId = 1, PhoneNumber = "123 456 789", Email = "prezydent@hotelix.pl" },
			new() { Id = 2, HotelId = 2, PhoneNumber = "123 456 789" },
			new() { Id = 3, HotelId = 3, Email = "kierownik@hotelix.pl" },
			new() { Id = 4, HotelId = 4, PhoneNumber = "123 456 789", Email = "praktykant@hotelix.pl" },
			new() { Id = 5, HotelId = 5, PhoneNumber = "123 456 789" },
			new() { Id = 6, HotelId = 6, Email = "senior@hotelix.pl" }
		});
	}
}
