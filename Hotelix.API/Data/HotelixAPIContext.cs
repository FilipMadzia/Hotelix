using Microsoft.EntityFrameworkCore;
using Hotelix.API.Data.Entities;
using Hotelix.API.Data.Seeders;

namespace Hotelix.API.Data;

public class HotelixAPIContext : DbContext
{
    public DbSet<CityEntity> Cities { get; set; }

    public HotelixAPIContext(DbContextOptions<HotelixAPIContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		CitiesSeeder.Seed(builder);
	}
}
