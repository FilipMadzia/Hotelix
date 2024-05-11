using Hotelix.Mobile.Models;
using Hotelix.Mobile.Services;
namespace Hotelix.Mobile;

public partial class MainPage : ContentPage
{
	public List<Hotel> Hotels { get; set; }

	public MainPage()
	{
		Hotels = Task.Run(() => HotelsService.GetHotelsAsync()).Result;
		
		InitializeComponent();

		BindingContext = this;
	}
}
