using Hotelix.API.Data;
using Hotelix.API.Data.Entities;

namespace Hotelix.API.Repositories;

public class ContactRepository(HotelixAPIContext context) : BaseRepository<ContactEntity>(context) { }
