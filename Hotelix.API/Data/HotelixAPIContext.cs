using Hotelix.Api.Data.Entities;
using Hotelix.Api.Data.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.Api.Data;

public class HotelixAPIContext(DbContextOptions<HotelixAPIContext> options) : DbContext(options)
{
	public DbSet<CityEntity> Cities { get; set; } = default!;
	public DbSet<AddressEntity> Addresses { get; set; } = default!;
	public DbSet<HotelEntity> Hotels { get; set; } = default!;
	public DbSet<ContactEntity> Contacts { get; set; } = default!;
	public DbSet<UserEntity> Users { get; set; } = default!;

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.Entity<HotelEntity>()
			.Property(x => x.PricePerNight)
			.HasPrecision(10, 2);

		builder.Entity<HotelEntity>()
			.HasOne(x => x.Address)
			.WithOne(x => x.Hotel)
			.HasForeignKey<AddressEntity>(x => x.HotelId);

		builder.Entity<HotelEntity>()
			.HasOne(x => x.Contact)
			.WithOne(x => x.Hotel)
			.HasForeignKey<ContactEntity>(x => x.HotelId);

		CitiesSeeder.Seed(builder);
		HotelsSeeder.Seed(builder);
		AddressesSeeder.Seed(builder);
		ContactsSeeder.Seed(builder);
		UsersSeeder.Seed(builder);
	}
}
