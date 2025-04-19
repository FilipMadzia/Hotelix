namespace Hotelix.Api.Models;

public class ContactGet
{
	public required int Id { get; set; }
	public string? PhoneNumber { get; set; }
	public string? Email { get; set; }
}
public class ContactPost
{
	public string? PhoneNumber { get; set; }
	public string? Email { get; set; }
}

public class ContactPut
{
	public string? PhoneNumber { get; set; }
	public string? Email { get; set; }
}
