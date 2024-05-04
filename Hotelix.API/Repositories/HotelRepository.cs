using Hotelix.API.Data;
using Hotelix.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.API.Repositories;

public class HotelRepository(HotelixAPIContext context) : BaseRepository<HotelEntity>(context)
{
	readonly HotelixAPIContext _context = context;

	public override async Task<IEnumerable<HotelEntity>> GetAllAsync() => await _context.Hotels
		.Where(x => !x.SoftDeleted)
		.Include(x => x.Address)
		.ThenInclude(x => x.City)
		.ToListAsync();

	public override async Task<HotelEntity?> GetAsync(int id) => await _context.Hotels
		.Where(x => !x.SoftDeleted)
		.Include(x => x.Address)
		.ThenInclude(x => x.City)
		.SingleOrDefaultAsync(x => x.Id == id);
}
