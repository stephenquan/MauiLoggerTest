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

	readonly ILogger logger;
	readonly ILogger<MauiLoggerTest.Heroes.Marvel.TonyStark> tonyStarkLogger;
	readonly ILogger<MauiLoggerTest.Heroes.Marvel.SteveRogers> steveRogersLogger;
	readonly ILogger<MauiLoggerTest.Heroes.DC.BruceWayne> bruceWayneLogger;
	readonly ILogger<MauiLoggerTest.Heroes.DC.BarryAllen> barryAllenLogger;

	/// <summary>
	/// Initializes a new instance of the <see cref="MainPage"/> class.
	/// </summary>
	/// <param name="logger">The logger instance used for general application logging.</param>
	/// <param name="tonyStarkLogger">The logger instance used for logging messages related to Tony Stark.</param>
	/// <param name="steveRogersLogger">The logger instance used for logging messages related to Steve Rogers.</param>
	/// <param name="bruceWayneLogger">The logger instance used for logging messages related to Bruce Wayne.</param>
	/// <param name="barryAllenLogger">The logger instance used for logging messages related to Barry Allen.</param>
	public MainPage(
		ILogger<MainPage> logger,
		ILogger<MauiLoggerTest.Heroes.Marvel.TonyStark> tonyStarkLogger,
		ILogger<MauiLoggerTest.Heroes.Marvel.SteveRogers> steveRogersLogger,
		ILogger<MauiLoggerTest.Heroes.DC.BruceWayne> bruceWayneLogger,
		ILogger<MauiLoggerTest.Heroes.DC.BarryAllen> barryAllenLogger)
	{
		this.logger = logger;
		this.tonyStarkLogger = tonyStarkLogger;
		this.steveRogersLogger = steveRogersLogger;
		this.bruceWayneLogger = bruceWayneLogger;
		this.barryAllenLogger = barryAllenLogger;

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

		logger.LogInformation("Counter clicked {Count} times", count);
		tonyStarkLogger.LogInformation("Tony Stark's counter clicked {Count} times", count);
		steveRogersLogger.LogInformation("Steve Rogers' counter clicked {Count} times", count);
		bruceWayneLogger.LogInformation("Bruce Wayne's counter clicked {Count} times", count);
		barryAllenLogger.LogInformation("Barry Allen's counter clicked {Count} times", count);

		if (count % 5 == 0)
		{
			logger.LogWarning("Counter reached a multiple of 5: {Count}", count);
			tonyStarkLogger.LogWarning("Tony Stark's counter reached a multiple of 5: {Count}", count);
			steveRogersLogger.LogWarning("Steve Rogers' counter reached a multiple of 5: {Count}", count);
			bruceWayneLogger.LogWarning("Bruce Wayne's counter reached a multiple of 5: {Count}", count);
			barryAllenLogger.LogWarning("Barry Allen's counter reached a multiple of 5: {Count}", count);
		}

		if (count % 10 == 0)
		{
			logger.LogError("Counter reached a multiple of 10: {Count}", count);
			tonyStarkLogger.LogError("Tony Stark's counter reached a multiple of 10: {Count}", count);
			steveRogersLogger.LogError("Steve Rogers' counter reached a multiple of 10: {Count}", count);
			bruceWayneLogger.LogError("Bruce Wayne's counter reached a multiple of 10: {Count}", count);
			barryAllenLogger.LogError("Barry Allen's counter reached a multiple of 10: {Count}", count);
		}

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}