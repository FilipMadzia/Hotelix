using Hotelix.Api.Data;
using Hotelix.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.Api.Repositories;

public class AddressRepository(HotelixAPIContext context) : BaseRepository<AddressEntity>(context)
{
	readonly HotelixAPIContext _context = context;

	public override async Task<IEnumerable<AddressEntity>> GetAllAsync() => await _context.Addresses
		.Where(x => !x.SoftDeleted)
		.Include(x => x.City)
		.ToListAsync();

	public override async Task<AddressEntity?> GetAsync(int id) => await _context.Addresses
		.Where(x => !x.SoftDeleted)
		.Include(x => x.City)
		.SingleOrDefaultAsync(x => x.Id == id);
}
