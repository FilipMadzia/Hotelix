using Hotelix.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.Api.Data.Seeders;

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
