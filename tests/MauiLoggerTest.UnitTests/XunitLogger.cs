using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace MauiLoggerTest.UnitTests;

/// <summary>
/// Provides a logger implementation that writes log messages to an xUnit test output.
/// </summary>
public class XunitLogger : ILogger
{
	String categoryName { get; } = string.Empty;

	/// <summary>
	/// Gets or sets the xUnit test output helper used to write log messages to the test output.
	/// </summary>
	public static ITestOutputHelper? OutputHelper { get; set; }

	/// <summary>
	/// Initializes a new instance of the XunitLogger class with the specified test output helper.
	/// </summary>
	/// <param name="categoryName"></param>
	public XunitLogger(string categoryName)
	{
		this.categoryName = categoryName;
	}

	/// <summary>
	/// Logs a formatted message with the specified log level, event ID, state, and exception.
	/// </summary>
	/// <typeparam name="TState">The type of the state object to be logged.</typeparam>
	/// <param name="logLevel">The severity level of the log message.</param>
	/// <param name="eventId">The identifier for the event being logged.</param>
	/// <param name="state">The state object containing the information to be logged.</param>
	/// <param name="exception">The exception related to the log entry, or <see langword="null"/> if no exception is associated.</param>
	/// <param name="formatter">A function that formats the state and exception into a log message string.</param>
	public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
	{
		OutputHelper?.WriteLine(categoryName + ": " + logLevel.ToString() + ": " + formatter(state, exception));
	}

	/// <summary>
	/// Determines whether logging is enabled for the specified log level.
	/// </summary>
	/// <param name="logLevel">The log level to check for logging enablement.</param>
	/// <returns><see langword="true"/> if logging is enabled for the specified <paramref name="logLevel"/>;
	/// otherwise, <see langword="false"/>.</returns>
	public bool IsEnabled(LogLevel logLevel)
	{
		return true;
	}

	/// <summary>
	/// Begins a logical operation scope.
	/// </summary>
	/// <typeparam name="TState">The type of the state to associate with the scope. Must be non-null.</typeparam>
	/// <param name="state">The state object to associate with the scope. This object is used to provide contextual information.</param>
	/// <returns>An <see cref="IDisposable"/> that ends the logical operation scope on disposal.
	/// Returns <see langword="null"/> if the scope is not supported.</returns>
	/// <exception cref="NotImplementedException"></exception>
	public IDisposable? BeginScope<TState>(TState state) where TState : notnull
	{
		throw new NotImplementedException();
	}
}
