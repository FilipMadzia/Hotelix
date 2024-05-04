using Hotelix.API.Data.Entities;
using Hotelix.API.Data.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.API.Data;

public class HotelixAPIContext : DbContext
{
	public DbSet<CityEntity> Cities { get; set; }
	public DbSet<AddressEntity> Addresses { get; set; }

	public HotelixAPIContext(DbContextOptions<HotelixAPIContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		CitiesSeeder.Seed(builder);
		AddressesSeeder.Seed(builder);
	}
}
