using CommunityToolkit.Maui;
using GuideMeApp.Data;
using GuideMeApp.Shared.Data;
using GuideMeApp.Shared.Repository;
using GuideMeApp.ViewModels;
using GuideMeApp.Views;
using InputKit.Handlers;
using Microsoft.EntityFrameworkCore;
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

            builder.Services.AddSingleton<GuideMeDatabase>();

            builder.Services.AddDbContext<LocalDbContext>(/*opt =>
        opt.UseSqlServer("your connection string should be add here")*/);

            builder.Services.AddScoped<ITripRepository, TripRepository>();
            builder.Services.AddScoped<ITripDetailRepository, TripDetailRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
