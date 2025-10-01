
using Microsoft.Extensions.Logging;

namespace MauiLoggerTest.Heroes.DC;

/// <summary>
/// This is an ILogger test class representing the character Bruce Wayne from the DC universe.
/// </summary>
public class BruceWayne
{
	/// <summary>
	/// Gets the logger instance for the <see cref="BruceWayne"/> class.
	/// </summary>
	public static ILogger? Logger { get; } = IPlatformApplication.Current?.Services.GetService<ILogger<BruceWayne>>();
}
