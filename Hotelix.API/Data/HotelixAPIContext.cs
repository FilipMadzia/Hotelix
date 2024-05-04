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
		builder.Entity<AddressEntity>(entity =>
		{
			entity.HasIndex(x => x.Id)
				.IsUnique();

			entity.HasOne(x => x.City)
				.WithMany(x => x.Addresses)
				.HasForeignKey(x => x.CityId);
		});

		builder.Entity<CityEntity>(entity =>
		{
			entity.HasIndex(x => x.Id)
				.IsUnique();
		});

		base.OnModelCreating(builder);

		CitiesSeeder.Seed(builder);
		AddressesSeeder.Seed(builder);
	}
}
