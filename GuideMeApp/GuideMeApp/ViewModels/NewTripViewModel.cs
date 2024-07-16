using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GuideMeApp.Shared.Models;
using GuideMeApp.Shared.Services;

namespace GuideMeApp.ViewModels
{
    [QueryProperty(nameof(Shared.Models.Trip), "Trip")]
    public partial class NewTripViewModel : ObservableObject
    {
        readonly ITripService _tripService;
        readonly IRoleService _roleService;
        readonly IUserService _userService;
        readonly IUserSettingService _userSettingService;

        [ObservableProperty]
        private Trip trip;

        [ObservableProperty]
        private TimeSpan time;

        public NewTripViewModel(ITripService tripService, IRoleService roleService, IUserService userService, IUserSettingService userSettingService)
        {
            _tripService = tripService;
            _roleService = roleService;
            _userService = userService;
            _userSettingService = userSettingService;
            Trip = new Trip { Date = DateTime.Now };
        }

        partial void OnTimeChanged(TimeSpan value)
        {
            Trip.Date += Time;
        }

        [RelayCommand]
        async Task Create()
        {
            var a = new Address() { AddressLine1 = "Demutstrasse 119", PostalCode="9000", City = "St.Gallen", Country = "Switzerland" };
            var u = _userService.GetAll().First();

            Trip.Address = a;
            Trip.GuideId = u.Id;
            Trip.Image = new byte[1];

            _tripService.Add(Trip);
            var t = _tripService.GetAll();
            await Shell.Current.GoToAsync("..");
        }
    }
}