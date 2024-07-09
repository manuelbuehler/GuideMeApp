using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GuideMeApp.Models;
using GuideMeApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GuideMeApp.ViewModels
{
    public partial class MyTripsViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Trip> bookedTrips;

        [ObservableProperty]
        ObservableCollection<Trip> createdTrips;

        public MyTripsViewModel()
        {
            BookedTrips = new ObservableCollection<Trip>();
            CreatedTrips = new ObservableCollection<Trip>();

            Address address = new Address
            {
                City = "Wallis",
                PostalCode = "4900",
                Country = "Switzerland",
                State = "Wallis",
            };

            var user = new User
            {
                FirstName = "Pascal",
                LastName = "Egli",
            };

            BookedTrips.Add(new Trip { Title = "Gletscher Wanderung", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!", Guide = user, Address = address });
            BookedTrips.Add(new Trip { Title = "Kanufahrt", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!", Guide = user, Address = address });
            BookedTrips.Add(new Trip { Title = "Velotour", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!", Guide = user, Address = address });
            BookedTrips.Add(new Trip { Title = "Velotour", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!", Guide = user, Address = address });
            CreatedTrips.Add(new Trip { Title = "Kanufahrt", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!", Guide = user, Address = address });
            CreatedTrips.Add(new Trip { Title = "Velotour", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!", Guide = user, Address = address });
            CreatedTrips.Add(new Trip { Title = "Kanufahrt", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!", Guide = user, Address = address });
            CreatedTrips.Add(new Trip { Title = "Velotour", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!", Guide = user, Address = address });
        }

        [RelayCommand]
        async Task Tap(Trip t)
        {
            await Shell.Current.GoToAsync(nameof(TripDetailPage), true, new Dictionary<string, object>() { { "Trip", t } });
        }

        [RelayCommand]
        async Task Cancel(Trip t)
        {
            bool answer = await Shell.Current.DisplayAlert("Buchung stornieren?", $"Sind Sie sicher, dass Sie den Ausflug \"{t.Title}\" stornieren wollen?", "Ja", "Nein");

            if (answer)
                BookedTrips.Remove(t);
        }

        [RelayCommand]
        async Task Edit(Trip t)
        {
            await Shell.Current.GoToAsync(nameof(NewTripPage), true, new Dictionary<string, object>() { { "Trip", t } });
        }
    }
}
