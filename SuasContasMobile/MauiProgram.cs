using SuasContasMobile.Services;
using SuasContasMobile.Services.Contracts;
using UraniumUI;

namespace SuasContasMobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseUraniumUI()
			.UseUraniumUIMaterial()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddMaterialIconFonts();
			});

		builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<CreateAccountViewModel>();
        builder.Services.AddSingleton<HomeViewModel>();

        builder.Services.AddSingleton<CreateAccountPage>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<IUserService, UserService>();

		return builder.Build();
	}
}
