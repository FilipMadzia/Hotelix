using Hotelix.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.API.Data.Seeders;

public class HotelsSeeder
{
	public static void Seed(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<HotelEntity>().HasData(new List<HotelEntity>
		{
			new() { Id = 1, Name = "Hotel Prezydent", Description = "Lorem Ipsum", CoverImagePath = Path.Combine("Images", "Covers", "background1.jpg") },
			new() { Id = 2, Name = "Hotel Prezes", CoverImagePath = Path.Combine("Images", "Covers", "background2.jpg") },
			new() { Id = 3, Name = "Hotel Kierownik", Description = "Lorem Ipsum", CoverImagePath = Path.Combine("Images", "Covers", "background3.jpg") },
			new() { Id = 4, Name = "Hotel Praktykant", CoverImagePath = Path.Combine("Images", "Covers", "background4.jpg")},
			new() { Id = 5, Name = "Hotel Stażysta", Description = "Lorem Ipsum", CoverImagePath = Path.Combine("Images", "Covers", "background5.jpg")},
			new() { Id = 6, Name = "Hotel Senior", CoverImagePath = Path.Combine("Images", "Covers", "background6.jpg")}
		});
	}
}
