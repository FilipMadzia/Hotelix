using Hotelix.Api.Data;
using Hotelix.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.Api.Repositories;

public class HotelRepository(HotelixDbContext context) : Repository<HotelEntity>(context)
{
	private readonly HotelixDbContext _context = context;

	public async Task<List<UserEntity>> GetEmployeesByHotelId(Guid hotelId)
	{
		var employees = await _context.Users
			.Where(x => x.HotelId == hotelId)
			.ToListAsync();
		
		return employees;
	}
}