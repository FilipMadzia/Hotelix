using Hotelix.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.API.Data.Seeders;

public class CitiesSeeder
{
	public static void Seed(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<CityEntity>().HasData(new List<CityEntity>
		{
			new() { Id = Guid.NewGuid(), Name = "Bielsko-Biała" },
			new() { Id = Guid.NewGuid(), Name = "Kraków" },
			new() { Id = Guid.NewGuid(), Name = "Katowice" }
		});
	}
}
