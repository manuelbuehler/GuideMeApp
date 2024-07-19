using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GuideMeApp.Shared.Models;
using GuideMeApp.Shared.Services;
using GuideMeApp.Utils;
using GuideMeApp.Views;
using System.Collections.ObjectModel;

namespace GuideMeApp.ViewModels
{
    public partial class MyTripsViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<TripDetail> bookedTrips;

        [ObservableProperty]
        ObservableCollection<Trip> createdTrips;

        readonly ITripService _tripService;
        readonly ITripDetailService _tripDetailService;
        readonly IPreferencesHelper _preferencesHelper;

        public MyTripsViewModel(ITripService tripService, ITripDetailService tripDetailService, IPreferencesHelper preferencesHelper)
        {
            BookedTrips = [];
            CreatedTrips = [];

            _tripService = tripService;
            _tripDetailService = tripDetailService;
            _preferencesHelper = preferencesHelper;
        }

        [RelayCommand]
        async Task Load()
        {
            var userId = _preferencesHelper.GetUserId();
            var createdTrips = await _tripService.GetUpcommingTripsByUserId(userId);
            var bookedTrips = await _tripDetailService.GetBookedTripsByUserId(userId);

            CreatedTrips.Clear();
            BookedTrips.Clear();

            createdTrips.ForEach(CreatedTrips.Add);
            bookedTrips.ForEach(BookedTrips.Add);
        }

        [RelayCommand]
        async Task Tap(Trip t)
        {
            await Shell.Current.GoToAsync(nameof(TripDetailPage), true, new Dictionary<string, object>() { { "Trip", t } });
        }

        [RelayCommand]
        async Task Cancel(TripDetail td)
        {
            bool answer = await Shell.Current.DisplayAlert("Buchung stornieren?", $"Sind Sie sicher, dass Sie den Ausflug \"{td.Trip.Title}\" stornieren wollen?", "Ja", "Nein");

            if (answer)
            {
                await _tripDetailService.RemoveAsync(td);
                BookedTrips.Remove(td);
            }
        }

        [RelayCommand]
        async Task Edit(Trip t)
        {
            await Shell.Current.GoToAsync(nameof(NewTripPage), true, new Dictionary<string, object>() { { "Trip", t } });
        }
    }
}
