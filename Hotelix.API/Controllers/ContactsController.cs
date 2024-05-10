using Hotelix.API.Models;
using Hotelix.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hotelix.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController(ContactRepository _contactRepository) : ControllerBase
{
	// GET: api/Contacts
	[HttpGet]
	[SwaggerResponse(200, type: typeof(IEnumerable<ContactGet>))]
	public async Task<IActionResult> Get()
	{
		var contactEntities = await _contactRepository.GetAllAsync();

		var contacts = contactEntities.Select(x => new ContactGet
		{
			Id = x.Id,
			PhoneNumber = x.PhoneNumber,
			Email = x.Email
		});

		return Ok(contacts);
	}

	// GET: api/Contacts/1
	[HttpGet("{id}")]
	[SwaggerResponse(200, type: typeof(ContactGet))]
	[SwaggerResponse(404)]
	public async Task<IActionResult> Get(int id)
	{
		var contactEntity = await _contactRepository.GetAsync(id);

		if(contactEntity == null) return NotFound();

		var contact = new ContactGet
		{
			Id = contactEntity.Id,
			PhoneNumber = contactEntity.PhoneNumber,
			Email = contactEntity.Email
		};

		return Ok(contact);
	}
}
