namespace Hotelix.API.Data.Entities;

public class UserEntity(string userName, string password) : BaseEntity
{
	public string UserName { get; set; } = userName;
	public string Password { get; set; } = password;
}
