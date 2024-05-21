using Hotelix.Mobile.Models;
using Hotelix.Mobile.Services;

namespace Hotelix.Mobile;

public partial class MainPage : ContentPage
{
	public List<Hotel> Hotels { get; set; }
	public List<City> Cities { get; set; }

	public MainPage(HotelsService _hotelsService, CitiesService _citiesService)
	{
		Hotels = Task.Run(_hotelsService.GetHotelsAsync).Result;
		Cities = Task.Run(_citiesService.GetCitiesAsync).Result;

		InitializeComponent();

		BindingContext = this;
	}

	private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		if(e.SelectedItem is Hotel selectedHotel)
		{
			await Navigation.PushAsync(new DetailPage(selectedHotel));
		}
	}
}
