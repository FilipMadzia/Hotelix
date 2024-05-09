using Hotelix.API.Models;
using Hotelix.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hotelix.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(
	IConfiguration _configuration,
	UserRepository _userRepository) : ControllerBase
{
	[HttpPost]
	public async Task<IActionResult> Auth([FromBody] UserPost user)
	{
		var userEntity = await _userRepository.GetByUserNameAsync(user.UserName);

		if(userEntity == null || user.Password != userEntity.Password) return Unauthorized();

		var issuer = _configuration["Jwt:Issuer"];
		var audience = _configuration["Jwt:Audience"];
		var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
		var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature);

		var subject = new ClaimsIdentity(new[]
		{
			new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
			new Claim(JwtRegisteredClaimNames.Email, user.UserName)
		});

		var expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpireTime"]!));

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = subject,
			Expires = expires,
			Issuer = issuer,
			Audience = audience,
			SigningCredentials = signingCredentials
		};

		var tokenHandler = new JwtSecurityTokenHandler();
		var token = tokenHandler.CreateToken(tokenDescriptor);
		var jwtToken = tokenHandler.WriteToken(token);

		return Ok(jwtToken);
	}
}
