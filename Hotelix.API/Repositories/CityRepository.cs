using Hotelix.API.Data;
using Hotelix.API.Data.Entities;

namespace Hotelix.API.Repositories;

public class CityRepository(
	HotelixAPIContext context,
	AddressRepository _addressRepository,
	HotelRepository _hotelRepository) : BaseRepository<CityEntity>(context)
{
	readonly HotelixAPIContext _context = context;

	public override void SoftDelete(CityEntity city)
	{
		var addresses = _context.Addresses.Where(x => x.City == city).ToList();
		var hotels = _context.Hotels.Where(x => x.Address.City == city).ToList();

		foreach(var address in addresses)
		{
			_addressRepository.SoftDelete(address);
		}

		foreach(var hotel in hotels)
		{
			_hotelRepository.SoftDelete(hotel);
		}

		base.SoftDelete(city);
	}
}
