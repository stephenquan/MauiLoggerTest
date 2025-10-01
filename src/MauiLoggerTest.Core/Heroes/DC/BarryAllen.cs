
using Microsoft.Extensions.Logging;

namespace MauiLoggerTest.Core.Heroes.DC;

/// <summary>
/// This is an ILogger test class representing the character Barry Allen from the DC universe.
/// </summary>
public class BarryAllen
{
	/// <summary>
	/// Gets the logger instance for the <see cref="BarryAllen"/> class.
	/// </summary>
	public static ILogger? Logger { get; } = AppServices.GetService<ILogger<BarryAllen>>();
}
