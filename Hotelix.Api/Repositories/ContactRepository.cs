using Hotelix.Api.Data;
using Hotelix.Api.Data.Entities;

namespace Hotelix.Api.Repositories;

public class ContactRepository(HotelixApiContext context) : Repository<ContactEntity>(context) { }
