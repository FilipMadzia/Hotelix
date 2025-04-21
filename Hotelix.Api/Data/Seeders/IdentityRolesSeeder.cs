using Hotelix.Api.Data.Enums;
using Microsoft.AspNetCore.Identity;

namespace Hotelix.Api.Data.Seeders;

public static class IdentityRolesSeeder
{
	public static async Task Seed(WebApplication app)
	{
		using var scope = app.Services.CreateScope();
		
		var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

		foreach(string role in Enum.GetValues(typeof(IdentityRoles)))
		{
			if(!await roleManager.RoleExistsAsync(role))
				await roleManager.CreateAsync(new IdentityRole(role));
		}
	}
}