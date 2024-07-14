using CommunityToolkit.Maui;
using Template.Common.Extensions;
using Template.Common.Interfaces;
using Template.Common.Services;

namespace Template;

/// <summary>
/// MAUI entry point 
/// </summary>
public static class MauiProgram
{
	/// <summary>
	/// Creates the app.
	/// Declares the font, depedenc
	/// y injection components
	/// </summary>
	/// <returns></returns>
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()	
			.RegisterViewModelsAndServices()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.Services.AddLocalization();
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();
        return builder.Build();
	}
}
