namespace Hotelix.API.Models;

public class CityGet
{
	public required int Id { get; set; }
	public required string Name { get; set; }
}

public class CityPost
{
	public required string Name { get; set; }
}

public class CityPut
{
	public required string Name { get; set; }
}
