using Hotelix.Api.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.Api.Data;

public class HotelixApiContext(DbContextOptions<HotelixApiContext> options)
	: IdentityDbContext<UserEntity, IdentityRole<int>, int>(options)
{
	public DbSet<CityEntity> Cities { get; set; }
	public DbSet<AddressEntity> Addresses { get; set; }
	public DbSet<HotelEntity> Hotels { get; set; }
	public DbSet<ContactEntity> Contacts { get; set; }
	public DbSet<UserEntity> Users { get; set; }
}
