namespace Hotelix.API.Models;

public class HotelGet
{
	public required int Id { get; set; }
	public required string Name { get; set; }
	public string? Description { get; set; }
	public required AddressGet Address { get; set; }
	public required ContactGet Contact { get; set; }
}

public class HotelPost
{
	public required string Name { get; set; }
	public string? Description { get; set; }
	public required AddressPost Address { get; set; }
	public required ContactPost Contact { get; set; }
}

public class HotelPut
{
	public required string Name { get; set; }
	public string? Description { get; set; }
	public required AddressPut Address { get; set; }
	public required ContactPut Contact { get; set;}
}
