namespace Hotelix.Api.Repositories;

public interface IRepository<T>
{
	public Task<IList<T>> GetAllAsync();
	public Task<T?> GetByIdAsync(Guid id);
	public Task AddAsync(T entity);
	public Task UpdateAsync(T entity);
	public Task SoftDeleteByIdAsync(Guid id);
	public Task SoftDeleteAsync(T entity);
}