using Hotelix.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.Api.Data.Seeders;

public class UsersSeeder
{
	public static void Seed(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<UserEntity>().HasData(new List<UserEntity>
		{
			new("FilipMadzia", "fikunia123") { Id = 1 },
			new("WojtekWróbel", "kochamBobry") { Id = 2 }
		});
	}
}
