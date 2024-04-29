using Hotelix.API.Data;
using Hotelix.API.Data.Entities;

namespace Hotelix.API.Repositories;

public class CityRepository : BaseRepository<CityEntity>
{
	public CityRepository(HotelixAPIContext context) : base(context) { }
}
