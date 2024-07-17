using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GuideMeApp.Shared.Models;
using GuideMeApp.Shared.Repositories;

namespace GuideMeApp.ViewModels
{
    [QueryProperty(nameof(Trip), "Trip")]
    public partial class TripDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        Trip? trip;

        readonly ITripDetailRepository _tripDetailRepository;

        public TripDetailViewModel(ITripDetailRepository tripDetailRepository)
        {
            _tripDetailRepository = tripDetailRepository;
        }

        [RelayCommand]
        async Task Book()
        {
            var td = new TripDetail() { };

            await Shell.Current.DisplayAlert("Buchung erfolgreich!", $"Der Ausflug wurde erfolgreich gebucht und ist nun unter \"Meine Ausflüge\" zu finden", "OK");
            await Shell.Current.GoToAsync("..");
        }
    }
}
