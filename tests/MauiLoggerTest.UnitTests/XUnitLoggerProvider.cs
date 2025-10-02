using Microsoft.Extensions.Logging;

namespace MauiLoggerTest.UnitTests;

/// <summary>
/// Implements a logger provider for xUnit tests.
/// </summary>
public partial class XUnitLoggerProvider : ILoggerProvider
{
	/// <summary>
	/// Creates a new instance of the <see cref="XUnitLoggerProvider"/> class.
	/// </summary>
	public XUnitLoggerProvider()
	{
	}

	/// <summary>
	/// Creates a logger for the specified category name.
	/// </summary>
	/// <param name="categoryName"></param>
	/// <returns></returns>
	public ILogger CreateLogger(string categoryName)
	{
		return new XunitLogger(categoryName);
	}

	/// <summary>
	/// Releases all resources used by the current instance of the class.
	/// </summary>
	public void Dispose()
	{
		Dispose(true);
	}

	/// <summary>
	/// Releases the resources used by the current instance of the class.
	/// </summary>
	/// <param name="disposing"><see langword="true"/> to release both managed and unmanaged resources;
	/// <see langword="false"/> to release only unmanaged resources.</param>
	protected virtual void Dispose(bool disposing)
	{
	}
}
