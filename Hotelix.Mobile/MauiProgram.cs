using Hotelix.Mobile.Models;
using Hotelix.Mobile.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;
namespace Hotelix.Mobile
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

			var a = Assembly.GetExecutingAssembly();
			using var stream = a.GetManifestResourceStream("Hotelix.Mobile.appsettings.json");

			var config = new ConfigurationBuilder()
					.AddJsonStream(stream)
					.Build();


			builder.Configuration.AddConfiguration(config);

			builder.Services.AddTransient<HotelsService>();
			builder.Services.AddTransient<CitiesService>();

			builder.Services.AddTransient<MainPage>();
			builder.Services.AddTransient<DetailPage>();

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
