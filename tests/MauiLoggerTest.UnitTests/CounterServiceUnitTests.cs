
using MauiLoggerTest.Core;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace MauiLoggerTest.UnitTests;

#pragma warning disable CS1591

/// <summary>
/// XUnit tests for the <see cref="CounterService"/> class.
/// To run these test with Xunit logging use the following command:
/// dotnet test --logger "console;verbosity=detailed"
/// </summary>
public class CounterServiceUnitTests
{
	public CounterServiceUnitTests(ITestOutputHelper testOutputHelper)
	{
		XunitLogger.OutputHelper = testOutputHelper;

		var SC = new ServiceCollection();
		SC.AddLogging(configure =>
		{
			configure.ClearProviders();
			configure.SetMinimumLevel(LogLevel.Trace);
			configure.AddProvider(new XUnitLoggerProvider());
		});
		var SP = SC.BuildServiceProvider();

		AppServices.Services = SP;
	}

	[Fact]
	public void Increment_ShouldIncreaseCountByOne()
	{
		var counterService = new CounterService();
		Assert.Equal(0, counterService.Count);
		counterService.Increment();
		Assert.Equal(1, counterService.Count);
	}
}
