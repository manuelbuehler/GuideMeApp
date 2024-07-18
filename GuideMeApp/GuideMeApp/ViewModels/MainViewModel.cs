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


            //    Address address = new Address
            //    {
            //        Street = "Malvenweg 3",
            //        City = "Wallis",
            //        PostalCode = "4900",
            //        Country = "Switzerland",
            //        State = "Wallis",
            //    };

            //    var user = new User
            //    {
            //        FirstName = "Pascal",
            //        LastName = "Egli",
            //    };

            //    Trips.Add(new Trip { Title = "Gletscher Wanderung", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!"/*, Guide = user, Address = address */});
            //    Trips.Add(ne
            //
            //
            //    w Trip { Title = "Kanufahrt", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!"/*, Guide = user, Address = address */});
            //    Trips.Add(new Trip { Title = "Velotour", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!"/*, Guide = user, Address = address*/ });
        }

        [RelayCommand]
        async Task Load()
        {
            var u = await _userService.GetByIdAsync(1);

            if (u is null)
            {
                var us = new UserSetting() { BlinkBlocker = false, HighContrast = false, ScreenReader = false, TextEnlargement = false, TextReader = false, VoiceCommands = false };
                var a = new Address() { AddressLine1 = "Demutstrasse 119", City = "St.Gallen", Country = "CH", PostalCode = "9000" };
                var r = new Role() { Id = 1, Name = "Admin" };

                await _userSettingService.AddAsync(us);
                await _roleService.AddAsync(r);

                u = new User() { Id = 1, BirthDate = DateTime.Now, FirstName = "Pascal", LastName = "Egli", UserSettingId = us.Id, UserGroup = UserGroups.Alle, RoleId = r.Id };

                await _userService.AddAsync(u);
                _preferencesHelper.SetUserId(u.Id);
            }


            var trips = await _tripService.GetUpcommingTrips();
            Trips.Clear();
            trips.ForEach(Trips.Add);
        }

        [RelayCommand]
        async Task Tap(Trip t)
        {
            await Shell.Current.GoToAsync(nameof(TripDetailPage), true, new Dictionary<string, object>() { { "Trip", t } });
        }
    }
}
