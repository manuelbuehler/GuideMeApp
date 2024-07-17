using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using GuideMeApp.Shared.Models;
using GuideMeApp.Views;
using GuideMeApp.Shared.Services;

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

        public MainViewModel(ITripService tripService, IUserService userService, IRoleService roleService, IUserSettingService userSettingService)
        {
            Trips = [];
            _tripService = tripService;
            _userService = userService;
            _roleService = roleService;
            _userSettingService = userSettingService;


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
            var uList = await _userService.GetAllAsync();
            var u = uList.FirstOrDefault();

            if (u is null)
            {
                var us = new UserSetting() { BlinkBlocker = false, HighContrast = false, ScreenReader=false, TextEnlargement=false, TextReader=false, VoiceCommands=false };
                var a = new Address() { AddressLine1 = "Demutstrasse 119", City = "St.Gallen", Country = "CH", PostalCode = "9000" };
                var r = new Role() { Id = 1, Name = "Admin" };
                
                await _userSettingService.AddAsync(us);
                await _roleService.AddAsync(r);

                await _userService.AddAsync(new User() { Id = 1, BirthDate = DateTime.Now, FirstName = "Pascal", LastName = "Egli", UserSettingId = us.Id, UserGroup = UserGroups.Alle, RoleId = r.Id });
            }
            

            var trips = await _tripService.GetAllAsync();
            Trips.Clear();
            trips.ForEach(t => Trips.Add(t));
        }

        [RelayCommand]
        async Task Tap(Trip t)
        {
            await Shell.Current.GoToAsync(nameof(TripDetailPage), true, new Dictionary<string, object>() { { "Trip", t } });
        }
    }
}
