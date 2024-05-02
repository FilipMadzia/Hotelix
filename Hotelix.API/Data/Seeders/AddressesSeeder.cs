using Hotelix.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.API.Data.Seeders;

public class AddressesSeeder
{
	public static void Seed(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<AddressEntity>().HasData(new List<AddressEntity>
		{
			// Bielsko-Biała
			new() { Id = 1, CityId = 1, Street = "Tańskiego", HouseNumber = 10, PostalCode = "43-382" },
			new() { Id = 2, CityId = 1, Street = "Słowackiego", HouseNumber = 12, PostalCode = "43-345" },

			// Kraków
			new() { Id = 3, CityId = 2, Street = "Wojska polskiego", HouseNumber = 1, PostalCode = "31-436" },
			new() { Id = 4, CityId = 2, Street = "Powstańców", HouseNumber = 24, PostalCode = "31-450" },

			// Katowice
			new() { Id = 5, CityId = 3, Street = "Węglowa", HouseNumber = 34, PostalCode = "40-102" },
			new() { Id = 6, CityId = 3, Street = "Kopalniana", HouseNumber = 4, PostalCode = "40-304" },
		});
	}
}
