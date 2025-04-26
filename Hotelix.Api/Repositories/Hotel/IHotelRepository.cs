using Hotelix.Api.Data.Entities;

namespace Hotelix.Api.Repositories.Hotel;

public interface IHotelRepository : IRepository<HotelEntity>
{
	public Task<HotelEntity?> GetByIdIncludingAsync(Guid id);
	public Task<IList<UserEntity>> GetEmployeesByHotelId(Guid hotelId);
}