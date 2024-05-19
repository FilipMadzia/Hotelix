using Hotelix.Mobile.Models;

namespace Hotelix.Mobile
{
    public partial class DetailPage : ContentPage
    {
        public Hotel SelectedHotel { get; set; }

        public DetailPage(Hotel selectedHotel)
        {
            InitializeComponent();
            SelectedHotel = selectedHotel;
            BindingContext = SelectedHotel;
        }
    }
}
