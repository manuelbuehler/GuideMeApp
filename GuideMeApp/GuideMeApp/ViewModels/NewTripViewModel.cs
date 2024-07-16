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

        [ObservableProperty]
        private Trip trip;

        [ObservableProperty]
        private TimeSpan time;

        public NewTripViewModel(ITripService tripService)
        {
            _tripService = tripService;
            Trip = new Trip { Date = DateTime.Now };
        }

        partial void OnTimeChanged(TimeSpan value)
        {
            Trip.Date += Time;
        }

        [RelayCommand]
        async Task Create()
        {
            var a = new Address() { AddressLine1 = "Demutsstrasse 119", PostalCode="9000", City="St.Gallen", Country= "CH" };
            var r = new Role() { Name = "Admin" };
            var us  = new UserSetting() { BlinkBlocker=false, HighContrast=false, ScreenReader=false, TextEnlargement=false, TextReader=false, VoiceCommands=false };

            var u = new User { FirstName="Pascal", LastName="Egli", Address = a, BirthDate=DateTime.Now, RoleId=r.Id, UserGroup=UserGroups.Alle/*, UserSettingId=us.Id */};

            //var r = new Role(){ Id = new Guid(), Name = "Admin" };
            //_roleService.Add(r);

            //_tripService.Add(Trip);
            await Shell.Current.GoToAsync("..");
        }
    }
}