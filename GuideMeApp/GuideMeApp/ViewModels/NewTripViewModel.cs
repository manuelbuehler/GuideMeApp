using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GuideMeApp.Data;
using GuideMeApp.Shared.Models;

namespace GuideMeApp.ViewModels
{
    [QueryProperty(nameof(Shared.Models.Trip), "Trip")]
    public partial class NewTripViewModel : ObservableObject
    {
        private readonly GuideMeDatabase _database;

        [ObservableProperty]
        private Trip trip;

        [ObservableProperty]
        private TimeSpan time;

        public NewTripViewModel(GuideMeDatabase database)
        {
            _database = database;
            Trip = new Trip { Date = DateTime.Now };
        }

        partial void OnTimeChanged(TimeSpan value)
        {
            Trip.Date += Time;
        }

        [RelayCommand]
        async Task Create()
        {
            await _database.CreateTripAsync(Trip);
            await Shell.Current.GoToAsync("..");
        }
    }
}