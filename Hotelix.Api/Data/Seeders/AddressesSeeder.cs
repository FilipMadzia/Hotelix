using Hotelix.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.Api.Data.Seeders;

public class AddressesSeeder
{
	public static void Seed(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<AddressEntity>().HasData(new List<AddressEntity>
		{
			// Bielsko-Biała
			new() { Id = 1, CityId = 1, HotelId = 1, Street = "Tańskiego", HouseNumber = 10, PostalCode = "43-382" },
			new() { Id = 2, CityId = 1, HotelId = 2, Street = "Słowackiego", HouseNumber = 12, PostalCode = "43-345" },

			// Kraków
			new() { Id = 3, CityId = 2, HotelId = 3, Street = "Wojska polskiego", HouseNumber = 1, PostalCode = "31-436" },
			new() { Id = 4, CityId = 2, HotelId = 4, Street = "Powstańców", HouseNumber = 24, PostalCode = "31-450" },

			// Katowice
			new() { Id = 5, CityId = 3, HotelId = 5, Street = "Węglowa", HouseNumber = 34, PostalCode = "40-102" },
			new() { Id = 6, CityId = 3, HotelId = 6, Street = "Kopalniana", HouseNumber = 4, PostalCode = "40-304" },
		});
	}
}
