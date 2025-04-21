using Microsoft.AspNetCore.Identity;

namespace Hotelix.Api.Data.Entities;

public class UserEntity : IdentityUser
{
	public bool SoftDeleted { get; set; }
}
