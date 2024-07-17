using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GuideMeApp.Shared.Models;
using GuideMeApp.Shared.Repositories;
using GuideMeApp.Utils;

namespace GuideMeApp.ViewModels
{
    [QueryProperty(nameof(Trip), "Trip")]
    public partial class TripDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        Trip trip;

        readonly ITripDetailRepository _tripDetailRepository;
        readonly IPreferencesHelper _preferencesHelper;

        public TripDetailViewModel(ITripDetailRepository tripDetailRepository, IPreferencesHelper preferencesHelper)
        {
            _tripDetailRepository = tripDetailRepository;
            _preferencesHelper = preferencesHelper;
        }

        [RelayCommand]
        async Task Book()
        {
            var userId = _preferencesHelper.GetUserId();
            var td = new TripDetail(userId, Trip.Id);
            await _tripDetailRepository.AddAsync(td);

            await Shell.Current.DisplayAlert("Buchung erfolgreich!", $"{Trip.Title} wurde erfolgreich gebucht und ist nun unter \"Meine Ausflüge\" zu finden", "OK");
            await Shell.Current.GoToAsync("..");
        }
    }
}
