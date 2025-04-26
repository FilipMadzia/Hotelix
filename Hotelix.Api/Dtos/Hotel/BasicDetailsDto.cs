using Hotelix.Api.Data.Entities;

namespace Hotelix.Api.Dtos.Hotel;

public class BasicDetailsDto(HotelEntity hotelEntity)
{
	public string Name { get; set; } = hotelEntity.Name;
	public string? Description { get; set; } = hotelEntity.Description;
	public decimal PricePerNight { get; set; } = hotelEntity.PricePerNight;
	public BasicDetailsAddress Address { get; set; } = new BasicDetailsAddress(hotelEntity.Address);
	public BasicDetailsContact Contact { get; set; } = new BasicDetailsContact(hotelEntity.Contact);

	public class BasicDetailsAddress(AddressEntity addressEntity)
	{
		public string Street { get; set; } = addressEntity.Street;
		public int HouseNumber { get; set; } = addressEntity.HouseNumber;
		public string PostalCode { get; set; } = addressEntity.PostalCode;
		public string City { get; set; } = addressEntity.City.Name;
	}

	public class BasicDetailsContact(ContactEntity contactEntity)
	{
		public string? PhoneNumber { get; set; } = contactEntity.PhoneNumber;
		public string? Email { get; set; } = contactEntity.Email;
	}
}