using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Hotelix.Api.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Hotelix.Api.Helpers;

public class JwtHelper(
	UserManager<UserEntity> userManager,
	IConfiguration configuration
	)
{
	public async Task<string> GenerateJwtToken(UserEntity user)
	{
		var userRoles = await userManager.GetRolesAsync(user);
    
		var claims = new List<Claim>
		{
			new(ClaimTypes.NameIdentifier, user.Id),
			new(ClaimTypes.Name, user.UserName),
			new(JwtRegisteredClaimNames.Email, user.Email)
		};

		claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? throw new Exception("JWT Key is empty")));
		var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		var token = new JwtSecurityToken(
			issuer: configuration["Jwt:Issuer"],
			audience: configuration["Jwt:Audience"],
			claims: claims,
			expires: DateTime.UtcNow.AddMinutes(double.Parse(configuration["Jwt:ExpireTime"]!)),
			signingCredentials: credentials
		);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}

}