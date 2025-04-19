namespace Hotelix.Api.Data.Entities;

public class HotelEntity : BaseEntity
{
	public required string Name { get; set; }
	public string? Description { get; set; }
	public decimal PricePerNight { get; set; }
	public bool HasInternet { get; set; }
	public bool HasTelevision { get; set; }
	public bool HasParking { get; set; }
	public bool HasCafeteria { get; set; }

	public AddressEntity Address { get; set; } = null!;
	public ContactEntity Contact { get; set; } = null!;

	public void Update(string name, string? description, decimal pricePerNight, bool hasInternet = false, bool hasTelevision = false, bool hasParking = false, bool hasCafeteria = false)
	{
		Name = name;
		Description = description;
		PricePerNight = pricePerNight;
		HasInternet = hasInternet;
		HasTelevision = hasTelevision;
		HasParking = hasParking;
		HasCafeteria = hasCafeteria;
	}
}
