namespace Hotelix.API.Repositories;

public interface IBaseRepository<T> where T : class
{
	Task<IEnumerable<T>> GetAllAsync();
	Task<T?> GetAsync(int id);
	Task AddAsync(T entity);
	void Update(T entity);
	void Delete(T entity);
	void SoftDelete(T entity);
	Task SaveChangesAsync();
}
