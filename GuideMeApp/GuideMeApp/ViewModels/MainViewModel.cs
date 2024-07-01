using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using GuideMeApp.Models;

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

            Trips.Add(new Trip { Title = "Gletscher Wanderung", Description = "Eine Wanderung durch die Gletscher", Guide = user, Address = address});
            Trips.Add(new Trip { Title = "Kanufahrt", Description = "Eine Fahrt im Kanu auf dem Fluss", Guide = user, Address = address });
            Trips.Add(new Trip { Title = "Velotour", Description = "Eine Radtour durch die Berge", Guide = user, Address = address });
        }
    }
}
