﻿using CommunityToolkit.Mvvm.ComponentModel;
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

            //Address address = new Address
            //{
            //    City = "Wallis",
            //    PostalCode = "4900",
            //    Country = "Switzerland",
            //    State = "Wallis",
            //};

            //var user = new User
            //{
            //    FirstName = "Pascal",
            //    LastName = "Egli",
            //};

            //BookedTrips.Add(new Trip { Title = "Gletscher Wanderung", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!"/*, Guide = user, Address = address */});
            //BookedTrips.Add(new Trip { Title = "Kanufahrt", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!"/*, Guide = user, Address = address */});
            //BookedTrips.Add(new Trip { Title = "Velotour", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!"/*, Guide = user, Address = address */});
            //BookedTrips.Add(new Trip { Title = "Velotour", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!"/*, Guide = user, Address = address */});
            //CreatedTrips.Add(new Trip { Title = "Kanufahrt", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!"/*, Guide = user, Address = address */});
            //CreatedTrips.Add(new Trip { Title = "Velotour", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!"/*, Guide = user, Address = address */});
            //CreatedTrips.Add(new Trip { Title = "Kanufahrt", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!"/*, Guide = user, Address = address */});
            //CreatedTrips.Add(new Trip { Title = "Velotour", Description = "Tauchen Sie ein in die faszinierende Welt der Gletscher und lassen Sie sich von der majestätischen Landschaft verzaubern. Diese Führung bietet Ihnen die einzigartige Möglichkeit, die Wunder der Natur hautnah zu erleben und dabei viel Wissenswertes zu erfahren. Ideal für Abenteurer und Naturliebhaber!"/*, Guide = user, Address = address */});
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
