using Hotelix.Mobile.Models;
using Hotelix.Mobile.Services;
using System.Collections.ObjectModel;

namespace Hotelix.Mobile
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Hotel> Hotels { get; set; }
        private List<Hotel> AllHotels { get; set; }
        public List<City> Cities { get; set; }
        public MainPage(HotelsService _hotelsService, CitiesService _citiesService)
        {
            AllHotels = Task.Run(_hotelsService.GetHotelsAsync).Result;
            Hotels = new ObservableCollection<Hotel>(AllHotels);
            Cities = Task.Run(_citiesService.GetCitiesAsync).Result;
            InitializeComponent();
            BindingContext = this;
        }

        private void CityPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterHotels();
        }

        private void FilterHotels()
        {
            var selectedCity = (City)CityPicker.SelectedItem;
            Hotels.Clear();

            var filteredHotels = AllHotels.AsQueryable();

            if (selectedCity != null)
            {
                filteredHotels = filteredHotels.Where(h => h.Address.City.Id == selectedCity.Id);
            }
            foreach (var hotel in filteredHotels.ToList())
            {
                Hotels.Add(hotel);
            }
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var hotel = e.SelectedItem as Hotel;

            if (hotel == null) return;

            await Navigation.PushAsync(new DetailPage(hotel));
        }
        private void ClearFiltersButton_Clicked(object sender, EventArgs e)
        {
            CityPicker.SelectedIndex = -1;  
            Hotels.Clear();

            foreach (var hotel in AllHotels)
            {
                Hotels.Add(hotel);
            }
        }
    }
}
