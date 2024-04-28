namespace Hotelix.API.Repositories;

public interface IBaseRepository<T> where T : class
{
	Task<IEnumerable<T>> GetAllAsync();
	Task<T?> GetAsync(Guid id);
	Task AddAsync(T entity);
	void Update(T entity);
	void Delete(Guid id);
	Task SoftDeleteAsync(Guid id);
	Task SaveChangesAsync();
}
