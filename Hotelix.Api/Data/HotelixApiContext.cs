using Hotelix.Api.Data.Entities;
using Hotelix.Api.Data.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.Api.Data;

public class HotelixApiContext(DbContextOptions<HotelixApiContext> options) : DbContext(options)
{
	public DbSet<CityEntity> Cities => Set<CityEntity>();
	public DbSet<AddressEntity> Addresses => Set<AddressEntity>();
	public DbSet<HotelEntity> Hotels => Set<HotelEntity>();
	public DbSet<ContactEntity> Contacts => Set<ContactEntity>();
	public DbSet<UserEntity> Users => Set<UserEntity>();

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
