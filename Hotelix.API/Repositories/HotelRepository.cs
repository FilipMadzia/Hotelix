using Hotelix.Api.Data;
using Hotelix.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotelix.Api.Repositories;

public class HotelRepository(
	HotelixAPIContext context,
	AddressRepository _addressRepository,
	ContactRepository _contactRepository) : BaseRepository<HotelEntity>(context)
{
	readonly HotelixAPIContext _context = context;

	public override async Task<IEnumerable<HotelEntity>> GetAllAsync() => await _context.Hotels
		.Where(x => !x.SoftDeleted)
		.Include(x => x.Address)
		.ThenInclude(x => x.City)
		.Include(x => x.Contact)
		.ToListAsync();

	public override async Task<HotelEntity?> GetAsync(int id) => await _context.Hotels
		.Where(x => !x.SoftDeleted)
		.Include(x => x.Address)
		.ThenInclude(x => x.City)
		.Include (x => x.Contact)
		.SingleOrDefaultAsync(x => x.Id == id);

	public override void SoftDelete(HotelEntity entity)
	{
		var address = _context.Addresses.Single(x => x.Id == entity.Id);
		var contact = _context.Contacts.Single(x => x.Id == entity.Id);

		_addressRepository.SoftDelete(address);
		_contactRepository.SoftDelete(contact);

		base.SoftDelete(entity);
	}
}
