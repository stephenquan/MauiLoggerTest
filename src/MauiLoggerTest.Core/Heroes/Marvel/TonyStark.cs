
using Microsoft.Extensions.Logging;

namespace MauiLoggerTest.Core.Heroes.Marvel;

/// <summary>
/// This is an ILogger test class representing the character Tony Stark from the Marvel universe.
/// </summary>
public class TonyStark
{
	/// <summary>
	/// Gets the logger instance for the <see cref="TonyStark"/> class.
	/// </summary>
	public static ILogger? Logger { get; set; } = AppServices.GetService<ILogger<TonyStark>>();
}
