using Hotelix.Api.Data;
using Hotelix.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.Api.Repositories.Hotel;

public class HotelRepository(HotelixDbContext context) : Repository<HotelEntity>(context), IHotelRepository
{
	private readonly HotelixDbContext _context = context;

	public async Task<IList<UserEntity>> GetEmployeesByHotelId(Guid hotelId)
	{
		var employees = await _context.Users
			.Where(x => x.HotelId == hotelId)
			.ToListAsync();
		
		return employees;
	}
}