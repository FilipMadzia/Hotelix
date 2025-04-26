using Hotelix.Api.Dtos.Hotel;
using Hotelix.Api.Repositories.Hotel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotelix.Api.Controllers;

[Route("api/[controller]/{id}/[action]")]
public class HotelController(IHotelRepository hotelRepository) : HotelixApiController
{
	[HttpGet]
	[Authorize(Roles = $"{HotelWorkerRole},{HotelManagerRole},{AdminRole}")]
	public async Task<IActionResult> BasicDetails(Guid id)
	{
		var hotelEntity = await hotelRepository.GetByIdIncludingAsync(id);
		
		if (hotelEntity == null)
			return NotFound();
	
		var dto = new BasicDetailsDto(hotelEntity);
		
		return Ok(dto);
	}
}