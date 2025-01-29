using CommunityToolkit.Maui;

using Controller.Maui.ViewModels;

using Microsoft.Extensions.Logging;

namespace Controller.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();

#endif          
            builder.Services.AddSingleton<HttpClient>();

            builder.Services.AddSingleton<MoveViewModel>();

            return builder.Build();

        }
    }
}
