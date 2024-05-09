using Hotelix.API.Data;
using Hotelix.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.API.Repositories;

public class UserRepository(HotelixAPIContext _context) : IUserRepository
{
	public async Task<IEnumerable<UserEntity>> GetAllAsync() => await _context.Users
		.Where(x => !x.SoftDeleted)
		.ToListAsync();

	public async Task<UserEntity?> GetAsync(int id) => await _context.Users
		.Where(x => !x.SoftDeleted)
		.SingleOrDefaultAsync(x => x.Id == id);

	public async Task<UserEntity?> GetByUserNameAsync(string userName) => await _context.Users
		.Where(x => !x.SoftDeleted)
		.SingleOrDefaultAsync(x => x.UserName == userName);
}
