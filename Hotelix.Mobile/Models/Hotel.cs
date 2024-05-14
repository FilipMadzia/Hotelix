namespace Hotelix.Mobile.Models;

public class Hotel
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
	public decimal PricePerNight { get; set; }
	public bool HasInternet { get; set; }
	public bool HasTelevision { get; set; }
	public bool HasParking { get; set; }
	public bool HasCafeteria { get; set; }
	public string? CoverImage { get; set; }
	public Address? Address { get; set; }
	public Contact? Contact { get; set; }
}
