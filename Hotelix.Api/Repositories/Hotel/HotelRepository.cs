using Hotelix.Api.Data;
using Hotelix.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.Api.Repositories.Hotel;

public class HotelRepository(HotelixDbContext context) : Repository<HotelEntity>(context), IHotelRepository
{
	private readonly HotelixDbContext _context = context;

	public async Task<HotelEntity?> GetByIdIncludingAsync(Guid id) => await _context.Hotels
			.Include(x => x.Address)
			.ThenInclude(x => x.City)
			.Include(x => x.Contact)
			.SingleOrDefaultAsync(x => x.Id == id && !x.SoftDeleted);

	public async Task<IList<UserEntity>> GetEmployeesByHotelId(Guid hotelId)
	{
		var employees = await _context.Users
			.Where(x => x.HotelId == hotelId)
			.ToListAsync();
		
		return employees;
	}
}