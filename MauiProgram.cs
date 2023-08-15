using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Netflix_Clone.Pages;
using Netflix_Clone.Services;
using Netflix_Clone.ViewModels;

namespace Netflix_Clone
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

            builder.Services.AddHttpClient(TMDBService.TmdbHttpClientName, HttpClient => HttpClient.BaseAddress = new Uri("https://api.themoviedb.org"));
            builder.Services.AddSingleton<TMDBService>();
            builder.Services.AddSingleton<HomeViewModel>(); 
            builder.Services.AddSingleton<MainPage>(); 

            return builder.Build();
        }
    }
}