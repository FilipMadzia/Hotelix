using Microsoft.AspNetCore.Identity;

namespace Hotelix.Api.Data.Entities;

public class UserEntity : IdentityUser<int>
{
	public bool SoftDeleted { get; set; }
}
