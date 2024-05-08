﻿using Hotelix.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.API.Data.Seeders;

public class HotelsSeeder
{
	public static void Seed(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<HotelEntity>().HasData(new List<HotelEntity>
		{
			new() { Id = 1, Name = "Hotel Prezydent", Description = "Lorem Ipsum" },
			new() { Id = 2, Name = "Hotel Prezes" },
			new() { Id = 3, Name = "Hotel Kierownik", Description = "Lorem Ipsum" },
			new() { Id = 4, Name = "Hotel Praktykant" },
			new() { Id = 5, Name = "Hotel Stażysta", Description = "Lorem Ipsum" },
			new() { Id = 6, Name = "Hotel Senior" }
		});
	}
}
