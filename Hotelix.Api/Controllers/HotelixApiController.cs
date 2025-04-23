using Hotelix.Api.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotelix.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public abstract class HotelixApiController : ControllerBase
{
	protected const string HotelWorkerRole = nameof(IdentityRoles.HotelWorker);
	protected const string HotelManagerRole = nameof(IdentityRoles.HotelManager);
	protected const string AdminRole = nameof(IdentityRoles.Administrator);
}