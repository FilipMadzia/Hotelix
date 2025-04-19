using Hotelix.Api.Data.Entities;

namespace Hotelix.Api.Repositories;

public interface IUserRepository
{
	Task<IEnumerable<UserEntity>> GetAllAsync();
	Task<UserEntity?> GetAsync(int id);
	Task<UserEntity?> GetByUserNameAsync(string userName);
}
