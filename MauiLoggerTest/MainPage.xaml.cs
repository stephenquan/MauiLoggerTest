
using MauiLoggerTest.Core;

namespace MauiLoggerTest;

/// <summary>
/// Represents the main page of the application, providing a user interface for interacting with the counter and
/// logging events related to various heroes.
/// </summary>
/// <remarks>This page includes functionality for incrementing a counter and logging related information using
/// multiple logger instances. Each logger is associated with a specific hero or general application context.</remarks>
public partial class MainPage : ContentPage
{
	CounterService countService = new();

	/// <summary>
	/// Initializes a new instance of the <see cref="MainPage"/> class.
	/// </summary>
	public MainPage()
	{
		InitializeComponent();
	}

	void OnCounterClicked(object? sender, EventArgs e)
	{
		countService.Increment();

		if (countService.Count == 1)
		{
			CounterBtn.Text = $"Clicked {countService.Count} time";
		}
		else
		{
			CounterBtn.Text = $"Clicked {countService.Count} times";
		}

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}
