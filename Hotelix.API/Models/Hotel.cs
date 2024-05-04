﻿namespace Hotelix.API.Models;

public class HotelGet
{
	public required int Id { get; set; }
	public required string Name { get; set; }
	public string? Description { get; set; }
	public required AddressGet Address { get; set; }
}

public class HotelPost
{
	public required string Name { get; set; }
	public string? Description { get; set; }
	public required int AddressId { get; set; }
}

public class HotelPut
{
	public required string Name { get; set; }
	public string? Description { get; set; }
	public required int AddressId { get; set; }
}
