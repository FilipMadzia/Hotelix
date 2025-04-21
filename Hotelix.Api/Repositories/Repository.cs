using Hotelix.Api.Data;
using Hotelix.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.Api.Repositories;

public abstract class Repository<T>(HotelixDbContext context) where T : Entity
{
	public async Task<IEnumerable<T>> GetAllAsync() => await context.Set<T>()
		.Where(x => !x.SoftDeleted)
		.ToListAsync();

	public async Task<T?> GetByIdAsync(Guid id) => await context.Set<T>()
		.SingleOrDefaultAsync(x => x.Id == id && !x.SoftDeleted);

	public async Task AddAsync(T entity)
	{
		await context.Set<T>().AddAsync(entity);
		await context.SaveChangesAsync();
	}

	public async Task Update(T entity)
	{
		entity.UpdatedAt = DateTime.Now;
		context.Update(entity);
		await context.SaveChangesAsync();
	}

	public async Task SoftDelete(T entity)
	{
		entity.SoftDeleted = true;
		await Update(entity);
	}
}
