using Hotelix.API.Data;
using Hotelix.API.Data.Entities;

namespace Hotelix.API.Repositories;

public class CityRepository(HotelixAPIContext context, AddressRepository addressRepository) : BaseRepository<CityEntity>(context)
{
	readonly HotelixAPIContext _context = context;
	readonly AddressRepository _addressRepository = addressRepository;

	public override void SoftDelete(CityEntity entity)
	{
		var addresses = _context.Addresses.Where(x => x.City == entity).ToList();

		foreach(var address in addresses)
		{
			_addressRepository.SoftDelete(address);
		}

		base.SoftDelete(entity);
	}
}
