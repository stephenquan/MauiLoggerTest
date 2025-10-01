
namespace MauiLoggerTest.UnitTests;

#pragma warning disable CS1591

public class CounterServiceUnitTests
{
	[Fact]
	public void Increment_ShouldIncreaseCountByOne()
	{
		var counterService = new CounterService();
		Assert.Equal(0, counterService.Count);
		counterService.Increment();
		Assert.Equal(1, counterService.Count);
	}
}
