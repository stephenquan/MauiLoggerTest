
using Microsoft.Extensions.Logging;

namespace MauiLoggerTest.Core.Heroes.Marvel;

/// <summary>
/// This is an ILogger test class representing the character Steve Rogers from the Marvel universe.
/// </summary>
public class SteveRogers
{
	/// <summary>
	/// Gets the logger instance for the <see cref="SteveRogers"/> class.
	/// </summary>
	public static ILogger? Logger { get; } = AppServices.GetService<ILogger<SteveRogers>>();
}
