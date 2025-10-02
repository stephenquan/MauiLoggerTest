
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

#if DEBUG
		builder.Logging.AddDebug();
		builder.Logging.AddConsole();

		// Change the default, i.e. turn on LogTrace with LogWarning and LogError.
		builder.Logging.SetMinimumLevel(LogLevel.Trace);

		// Turn on detailed trace for DC heroes but default or less than default settings for Marvel heroes.
		//builder.Logging.AddFilter("MauiLoggerTest.Heroes", LogLevel.Trace);
		builder.Logging.AddFilter("MauiLoggerTest.Heroes.Marvel", LogLevel.Debug);
		builder.Logging.AddFilter("MauiLoggerTest.Heroes.Marvel.TonyStark", LogLevel.None);

		// Apply experimental runtime filter.
		//builder.Logging.AddFilter(AppLoggingFilter.Current.DefaultFilter);
		//AppLoggingFilter.Current.Rules = "MainPage;Heroes;Marvel;DC";
#endif

		builder.Services.AddTransient<MainPage>();

		return builder.Build();
	}
}
