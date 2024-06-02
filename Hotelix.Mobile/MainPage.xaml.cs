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

            if (AllHotels.Any())
            {
                double minPrice = AllHotels.Min(h => (double)h.PricePerNight);
                double maxPrice = AllHotels.Max(h => (double)h.PricePerNight);
                MinPriceSlider.Minimum = minPrice;
                MinPriceSlider.Maximum = maxPrice;
                MaxPriceSlider.Minimum = minPrice;
                MaxPriceSlider.Maximum = maxPrice;
                MinPriceSlider.Value = minPrice;
                MaxPriceSlider.Value = maxPrice;
                MinPriceLabel.Text = minPrice.ToString("0");
                MaxPriceLabel.Text = maxPrice.ToString("0");
            }
        }

        private void CityPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterHotels();
        }

        private void OnPriceSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == MinPriceSlider)
            {
                MinPriceLabel.Text = MinPriceSlider.Value.ToString("0");
            }
            else if (sender == MaxPriceSlider)
            {
                MaxPriceLabel.Text = MaxPriceSlider.Value.ToString("0");
            }

            FilterHotels();
        }
        private void OnSwitchToggled(object sender, ToggledEventArgs e)
        {
            FilterHotels();
        }
        private void FilterHotels()
        {
            var selectedCity = (City)CityPicker.SelectedItem;
            double minPrice = MinPriceSlider.Value;
            double maxPrice = MaxPriceSlider.Value;
            Hotels.Clear();

            var filteredHotels = AllHotels.AsQueryable();

            if (selectedCity != null)
            {
                filteredHotels = filteredHotels.Where(h => h.Address.City.Id == selectedCity.Id);
            }

            filteredHotels = filteredHotels.Where(h => (double)h.PricePerNight >= minPrice && (double)h.PricePerNight <= maxPrice);
            filteredHotels = filteredHotels.Where(h =>
             (!InternetSwitch.IsToggled || h.HasInternet) &&
             (!TelevisionSwitch.IsToggled || h.HasTelevision) &&
             (!ParkingSwitch.IsToggled || h.HasTelevision) &&
             (!CafeteriaSwitch.IsToggled || h.HasCafeteria));
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
            MinPriceSlider.Value = MinPriceSlider.Minimum;
            MaxPriceSlider.Value = MaxPriceSlider.Maximum;
            MinPriceLabel.Text = MinPriceSlider.Minimum.ToString("0");
            MaxPriceLabel.Text = MaxPriceSlider.Maximum.ToString("0");
            InternetSwitch.IsToggled = false;
            TelevisionSwitch.IsToggled = false;
            ParkingSwitch.IsToggled = false;
            CafeteriaSwitch.IsToggled = false;
            Hotels.Clear();

            foreach (var hotel in AllHotels)
            {
                Hotels.Add(hotel);
            }
        }
    }
}
