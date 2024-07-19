using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using GuideMeApp.Shared.Models;
using GuideMeApp.Views;
using GuideMeApp.Shared.Services;
using GuideMeApp.Utils;

namespace GuideMeApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Trip> trips;

        readonly ITripService _tripService;
        readonly IUserService _userService;
        readonly IRoleService _roleService;
        readonly IUserSettingService _userSettingService;
        readonly IPreferencesHelper _preferencesHelper;

        public MainViewModel(ITripService tripService, IUserService userService, IRoleService roleService, IUserSettingService userSettingService, IPreferencesHelper preferencesHelper)
        {
            Trips = [];
            _tripService = tripService;
            _userService = userService;
            _roleService = roleService;
            _userSettingService = userSettingService;
            _preferencesHelper = preferencesHelper;
        }

        [RelayCommand]
        async Task Load()
        {
            var u = await _userService.GetByIdAsync(1);

            if (u is null)
            {
                var us = new UserSetting() { BlinkBlocker = false, HighContrast = false, ScreenReader = false, TextEnlargement = false, TextReader = false, VoiceCommands = false };
                var r = new Role() { Id = 1, Name = "Admin" };

                await _userSettingService.AddAsync(us);
                await _roleService.AddAsync(r);

                u = new User() { Id = 1, BirthDate = DateTime.Now, FirstName = "Pascal", LastName = "Egli", UserSettingId = us.Id, UserGroup = UserGroups.Alle, RoleId = r.Id };

                await _userService.AddAsync(u);
                _preferencesHelper.SetUserId(u.Id);
            }


            var upcommingTrips = await _tripService.GetUpcommingTrips();
            Trips.Clear();
            upcommingTrips.ForEach(Trips.Add);
        }

        [RelayCommand]
        async Task Tap(Trip t)
        {
            await Shell.Current.GoToAsync(nameof(TripDetailPage), true, new Dictionary<string, object>() { { "Trip", t } });
        }
    }
}
