﻿//https://www.syncfusion.com/blogs/post/designing-effective-data-entry-forms-in-net-maui-a-step-by-step-guide
//https://www.syncfusion.com/blogs/post/dotnet-maui-text-input-layout
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

        [ObservableProperty]
        ImageSource image;

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
            var u = await _userService.GetAllAsync();


            Trip.Address = a;
            Trip.GuideId = u.First().Id;
            Trip.Image = new byte[1];

            await _tripService.AddAsync(Trip);
            var t = await _tripService.GetAllAsync();
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task Upload()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Bild hochladen",
                FileTypes = FilePickerFileType.Images
            });

            if (result is null)
                return;

            var stream = await result.OpenReadAsync();
            Image = ImageSource.FromStream(() => stream);
        }
    }
}