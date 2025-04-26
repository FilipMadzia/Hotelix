using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hotelix.Api.Dtos.Auth;

public class LoginDto
{
	[EmailAddress]
	[DefaultValue("admin@admin.admin")]
	public required string Email { get; set; }
	[DefaultValue("admin")]
	public required string Password { get; set; }
}