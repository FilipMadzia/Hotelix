using Hotelix.API.Data.Entities;

namespace Hotelix.API.Repositories;

public interface IUserRepository
{
	Task<IEnumerable<UserEntity>> GetAllAsync();
	Task<UserEntity?> GetAsync(int id);
	Task<UserEntity?> GetByUserNameAsync(string userName);
}
