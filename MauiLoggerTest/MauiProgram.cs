using Microsoft.Extensions.Logging;

namespace MauiLoggerTest;

#pragma warning disable CS1591 // Suppress warnings for missing XML comments

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

		builder.Logging.AddDebug();
		builder.Logging.AddFilter(AppLoggingFilter.Current.DefaultFilter);

		AppLoggingFilter.Current.Rules = "MainPage;Heroes;Marvel;DC";

		builder.Services.AddTransient<MainPage>();

		return builder.Build();
	}
}
