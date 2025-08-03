using Android.App;
using Android.Runtime;

namespace MauiLoggerTest;

#pragma warning disable CS1591 // Suppress warnings for missing XML comments

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
