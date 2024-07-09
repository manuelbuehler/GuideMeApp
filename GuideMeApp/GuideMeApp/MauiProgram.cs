using CommunityToolkit.Maui;
using GuideMeApp.ViewModels;
using GuideMeApp.Views;
using InputKit.Handlers;
using Microsoft.Extensions.Logging;

namespace GuideMeApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureMauiHandlers(handlers =>
                {
                    handlers.AddInputKitHandlers();
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialIcons-Regular.ttf", "GoogleMaterialFont");
                });


            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddTransient<TripDetailPage>();
            builder.Services.AddTransient<TripDetailViewModel>();

            builder.Services.AddTransient<MyTripsPage>();
            builder.Services.AddTransient<MyTripsViewModel>();

            builder.Services.AddTransient<NewTripPage>();
            builder.Services.AddTransient<NewTripViewModel>();

            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<ProfileViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
