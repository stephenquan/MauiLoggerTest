
using Microsoft.Extensions.Logging;

namespace MauiLoggerTest;

/// <summary>
/// Represents the main page of the application, providing a user interface for interacting with the counter and
/// logging events related to various heroes.
/// </summary>
/// <remarks>This page includes functionality for incrementing a counter and logging related information using
/// multiple logger instances. Each logger is associated with a specific hero or general application context.</remarks>
public partial class MainPage : ContentPage
{
	int count = 0;

	/// <summary>
	/// Gets the logger instance used for general application logging.
	/// </summary>
	public static ILogger? Logger = IPlatformApplication.Current?.Services.GetService<ILogger<MainPage>>();

	/// <summary>
	/// Initializes a new instance of the <see cref="MainPage"/> class.
	/// </summary>
	public MainPage()
	{
		InitializeComponent();
	}

	void OnCounterClicked(object? sender, EventArgs e)
	{
		count++;

		if (count == 1)
		{
			CounterBtn.Text = $"Clicked {count} time";
		}
		else
		{
			CounterBtn.Text = $"Clicked {count} times";
		}

		Logger?.LogTrace("Counter clicked {Count} times", count);
		Heroes.Marvel.TonyStark.Logger?.LogTrace("Tony Stark's counter clicked {Count} times", count);
		Heroes.Marvel.SteveRogers.Logger?.LogTrace("Steve Rogers' counter clicked {Count} times", count);
		Heroes.DC.BruceWayne.Logger?.LogTrace("Bruce Wayne's counter clicked {Count} times", count);
		Heroes.DC.BarryAllen.Logger?.LogTrace("Barry Allen's counter clicked {Count} times", count);

		if (count % 5 == 0)
		{
			Logger?.LogWarning("Counter reached a multiple of 5: {Count}", count);
			Heroes.Marvel.TonyStark.Logger?.LogWarning("Tony Stark's counter reached a multiple of 5: {Count}", count);
			Heroes.Marvel.SteveRogers.Logger?.LogWarning("Steve Rogers' counter reached a multiple of 5: {Count}", count);
			Heroes.DC.BarryAllen.Logger?.LogWarning("Bruce Wayne's counter reached a multiple of 5: {Count}", count);
			Heroes.DC.BruceWayne.Logger?.LogWarning("Barry Allen's counter reached a multiple of 5: {Count}", count);
		}

		if (count % 10 == 0)
		{
			Logger?.LogError("Counter reached a multiple of 10: {Count}", count);
			Heroes.Marvel.TonyStark.Logger?.LogError("Tony Stark's counter reached a multiple of 10: {Count}", count);
			Heroes.Marvel.SteveRogers.Logger?.LogError("Steve Rogers' counter reached a multiple of 10: {Count}", count);
			Heroes.DC.BruceWayne.Logger?.LogError("Bruce Wayne's counter reached a multiple of 10: {Count}", count);
			Heroes.DC.BarryAllen.Logger?.LogError("Barry Allen's counter reached a multiple of 10: {Count}", count);
		}

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}
