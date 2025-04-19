using Hotelix.Api.Data;
using Hotelix.Api.Data.Entities;

namespace Hotelix.Api.Repositories;

public class ContactRepository(HotelixAPIContext context) : BaseRepository<ContactEntity>(context) { }
