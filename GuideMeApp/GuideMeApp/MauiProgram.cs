using CommunityToolkit.Maui;
using GuideMeApp.Shared.Data;
using GuideMeApp.Shared.Repositories;
using GuideMeApp.Shared.Services;
using GuideMeApp.Utils;
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

            builder.Services.AddSingleton<IPreferencesHelper, PreferencesHelper>();

            //    builder.Services.AddDbContext<LocalDbContext>(/*opt =>
            //opt.UseSqlServer("your connection string should be add here")*/);


            builder.Services.AddTransient<LocalDbContext>((services) =>
            {
                return new LocalDbContext(Path.Combine(FileSystem.AppDataDirectory, "SQLite002.db3"));
            });

            builder.Services.AddScoped<ITripRepository, TripRepository>();
            builder.Services.AddScoped<ITripDetailRepository, TripDetailRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IUserSettingRepository, UserSettingRepository>();

            builder.Services.AddScoped<ITripDetailService, TripDetailService>();
            builder.Services.AddScoped<ITripService, TripService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IUserSettingService, UserSettingService>();
            

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
