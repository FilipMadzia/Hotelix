using Hotelix.Api.Data.Entities;
using Hotelix.Api.Data.Enums;
using Hotelix.Api.Dtos.Auth;
using Hotelix.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotelix.Api.Controllers;

public class AuthController(UserManager<UserEntity> userManager, JwtHelper jwtHelper) : HotelixApiController
{
	[HttpPost]
	public async Task<IActionResult> Register(RegisterDto registerDto)
	{
		var user = new UserEntity { UserName = registerDto.Email, Email = registerDto.Email };
		var result = await userManager.CreateAsync(user, registerDto.Password);
		
		if (!result.Succeeded)
			return BadRequest(result.Errors);
		
		await userManager.AddToRoleAsync(user, nameof(IdentityRoles.HotelWorker));
		
		return Ok();
	}

	[HttpPost]
	[AllowAnonymous]
	public async Task<IActionResult> Login(LoginDto loginDto)
	{
		var user = await userManager.FindByEmailAsync(loginDto.Email);
		
		if (user == null || !await userManager.CheckPasswordAsync(user, loginDto.Password))
			return Unauthorized();
		
		var token = await jwtHelper.GenerateJwtToken(user);

		return Ok(token);
	}
}
