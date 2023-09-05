using PartsClient.Data;

namespace PartsClient;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		#if ANDROID && DEBUG
			MyApp.Platforms.Android.DangerousAndroidMessageHandlerEmitter.Register();
			MyApp.Platforms.Android.DangerousTrustProvider.Register();
		#endif
        return builder.Build();
	}
}
