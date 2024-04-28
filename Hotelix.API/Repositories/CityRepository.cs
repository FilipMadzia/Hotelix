using Hotelix.API.Data;
using Hotelix.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.API.Repositories;

public class CityRepository(HotelixAPIContext _context) : IBaseRepository<CityEntity>
{
	public async Task<IEnumerable<CityEntity>> GetAllAsync() => await _context.Cities
		.Where(x => !x.SoftDeleted)
		.ToListAsync();

	public async Task<CityEntity?> GetAsync(Guid id) => await _context.Cities.SingleOrDefaultAsync(x => x.Id == id);

	public async Task AddAsync(CityEntity entity) => await _context.Cities.AddAsync(entity);

	public void Update(CityEntity entity)
	{
		entity.UpdatedAt = DateTime.Now;
		_context.Entry(entity).State = EntityState.Modified;
	}

	public void Delete(Guid id) => _context.Remove(GetAsync(id) ?? throw new NullReferenceException());

	public async Task SoftDeleteAsync(Guid id)
	{
		var entity = await GetAsync(id);

		if(entity == null)
			throw new NullReferenceException();

		entity.SoftDeleted = true;
		Update(entity);
	}

	public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}
