using Microsoft.Extensions.Logging;

namespace MauiLoggerTest.Core;

/// <summary>
/// A sample class to demonstrate ILogger functionality in a MAUI application.
/// </summary>
public class CounterService
{
	/// <summary>
	/// Gets the logger instance for the <see cref="CounterService"/> class.
	/// </summary>
	public static ILogger? Logger { get; } = AppServices.GetService<ILogger<CounterService>>();

	/// <summary>
	/// Gets or sets the count value.
	/// </summary>
	public int Count { get; set; } = 0;

	/// <summary>
	/// Increments the count by 1.
	/// </summary>
	public void Increment()
	{
		Count++;

		Logger?.LogTrace("Counter clicked {Count} times", Count);
		Heroes.Marvel.TonyStark.Logger?.LogTrace("Tony Stark's counter clicked {Count} times", Count);
		Heroes.Marvel.SteveRogers.Logger?.LogTrace("Steve Rogers' counter clicked {Count} times", Count);
		Heroes.DC.BruceWayne.Logger?.LogTrace("Bruce Wayne's counter clicked {Count} times", Count);
		Heroes.DC.BarryAllen.Logger?.LogTrace("Barry Allen's counter clicked {Count} times", Count);

		// Simulate a warning condition.
		if (Count % 5 == 0)
		{
			Logger?.LogWarning("Counter reached a multiple of 5: {Count}", Count);
			Heroes.Marvel.TonyStark.Logger?.LogWarning("Tony Stark's counter reached a multiple of 5: {Count}", Count);
			Heroes.Marvel.SteveRogers.Logger?.LogWarning("Steve Rogers' counter reached a multiple of 5: {Count}", Count);
			Heroes.DC.BarryAllen.Logger?.LogWarning("Bruce Wayne's counter reached a multiple of 5: {Count}", Count);
			Heroes.DC.BruceWayne.Logger?.LogWarning("Barry Allen's counter reached a multiple of 5: {Count}", Count);
		}

		// Simulate an error condition.
		if (Count % 10 == 0)
		{
			Logger?.LogError("Counter reached a multiple of 10: {Count}", Count);
			Heroes.Marvel.TonyStark.Logger?.LogError("Tony Stark's counter reached a multiple of 10: {Count}", Count);
			Heroes.Marvel.SteveRogers.Logger?.LogError("Steve Rogers' counter reached a multiple of 10: {Count}", Count);
			Heroes.DC.BruceWayne.Logger?.LogError("Bruce Wayne's counter reached a multiple of 10: {Count}", Count);
			Heroes.DC.BarryAllen.Logger?.LogError("Barry Allen's counter reached a multiple of 10: {Count}", Count);
		}
	}
}
