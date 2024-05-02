using Hotelix.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.API.Data.Seeders;

public class CitiesSeeder
{
	public static void Seed(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<CityEntity>().HasData(new List<CityEntity>
		{
			new() { Id = 1, Name = "Bielsko-Biała" },
			new() { Id = 2, Name = "Kraków" },
			new() { Id = 3, Name = "Katowice" }
		});
	}
}
