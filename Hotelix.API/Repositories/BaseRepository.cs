using Hotelix.Api.Data;
using Hotelix.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.Api.Repositories;

public abstract class BaseRepository<T>(HotelixApiContext _context) : IBaseRepository<T> where T : BaseEntity
{
	public virtual async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>()
		.Where(x => !x.SoftDeleted)
		.ToListAsync();

	public virtual async Task<T?> GetAsync(int id) => await _context.Set<T>()
		.SingleOrDefaultAsync(x => x.Id == id);

	public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);

	public void Update(T entity)
	{
		entity.UpdatedAt = DateTime.Now;
		_context.Entry(entity).State = EntityState.Modified;
	}

	public virtual void Delete(T entity) => _context.Remove(entity);

	public virtual void SoftDelete(T entity)
	{
		entity.SoftDeleted = true;
		Update(entity);
	}

	public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}
