using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GuideMeApp.Models;

namespace GuideMeApp.ViewModels
{
    [QueryProperty(nameof(Trip), "Trip")]
    public partial class TripDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        Trip trip;

        [RelayCommand]
        async Task Book()
        {
            await Shell.Current.DisplayAlert("Buchung erfolgreich!", $"Der Ausflug wurde erfolgreich gebucht und ist nun unter \"Meine Ausflüge\" zu finden", "OK");
            await Shell.Current.GoToAsync("..");
        }
    }
}
