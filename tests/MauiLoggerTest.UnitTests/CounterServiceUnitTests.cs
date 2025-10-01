
using MauiLoggerTest.Core;
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
	ITestOutputHelper TestOutputHelper { get; }

	public CounterServiceUnitTests(ITestOutputHelper testOutputHelper)
	{
		TestOutputHelper = testOutputHelper;
		CounterService.Logger = new XunitLogger<CounterService>(TestOutputHelper);
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
