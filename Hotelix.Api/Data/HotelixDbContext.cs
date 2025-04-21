using Hotelix.Api.Data.Entities;
using Hotelix.Api.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.Api.Data;

public class HotelixDbContext(DbContextOptions<HotelixDbContext> options)
	: IdentityDbContext<UserEntity>(options)
{
	public DbSet<CityEntity> Cities { get; set; }
	public DbSet<AddressEntity> Addresses { get; set; }
	public DbSet<HotelEntity> Hotels { get; set; }
	public DbSet<ContactEntity> Contacts { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		var roles = Enum.GetValues<IdentityRoles>()
			.Select(role => new IdentityRole
			{
				Id = Guid.NewGuid().ToString(),
				Name = role.ToString(),
				NormalizedName = role.ToString().ToUpper(),
				ConcurrencyStamp = Guid.NewGuid().ToString()
			})
			.ToList();

		builder.Entity<IdentityRole>().HasData(roles);
	}
}
