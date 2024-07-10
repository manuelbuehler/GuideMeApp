using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GuideMeApp.Data;
using GuideMeApp.Models;

namespace GuideMeApp.ViewModels
{
    [QueryProperty(nameof(Models.Trip), "Trip")]
    public partial class NewTripViewModel(GuideMeDatabase database) : ObservableObject
    {
        [ObservableProperty]
        private Trip trip = new();

        [RelayCommand]
        async Task Create()
        {

            await database.CreateTripAsync(trip);
            await Shell.Current.GoToAsync("..");
        }
    }
}