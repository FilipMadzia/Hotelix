using Hotelix.API.Data;
using Hotelix.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.API.Repositories;

public class HotelRepository(HotelixAPIContext context, AddressRepository addressRepository) : BaseRepository<HotelEntity>(context)
{
	readonly HotelixAPIContext _context = context;
	readonly AddressRepository _addressRepository = addressRepository;

	public override async Task<IEnumerable<HotelEntity>> GetAllAsync() => await _context.Hotels
		.Where(x => !x.SoftDeleted)
		.Include(x => x.Address)
		.ThenInclude(x => x.City)
		.ToListAsync();

	public override async Task<HotelEntity?> GetAsync(int id) => await _context.Hotels
		.Where(x => !x.SoftDeleted)
		.Include(x => x.Address)
		.ThenInclude(x => x.City)
		.SingleOrDefaultAsync(x => x.Id == id);

	public override void SoftDelete(HotelEntity entity)
	{
		var address = _context.Addresses.Single(x => x.Id == entity.Id);

		_addressRepository.SoftDelete(address);

		base.SoftDelete(entity);
	}
}
