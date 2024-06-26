﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using GuideMeApp.Models;
using GuideMeApp.Views;

namespace GuideMeApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Trip> trips;

        public MainViewModel()
        {
            Trips = new ObservableCollection<Trip>();

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

            Trips.Add(new Trip { Title = "Gletscher Wanderung", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!", Guide = user, Address = address });
            Trips.Add(new Trip { Title = "Kanufahrt", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!", Guide = user, Address = address });
            Trips.Add(new Trip { Title = "Velotour", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!", Guide = user, Address = address });
        }

        [RelayCommand]
        async Task Tap(Trip t)
        {
            await Shell.Current.GoToAsync(nameof(TripDetailPage), true, new Dictionary<string, object>() { { "Trip", t } });
        }

    }
}
