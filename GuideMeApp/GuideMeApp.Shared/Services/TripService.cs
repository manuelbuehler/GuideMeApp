using GuideMeApp.Shared.Models;
using GuideMeApp.Shared.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GuideMeApp.Shared.Services
{
    public interface ITripService
    {
        List<Trip> GetAll();

        void Add(Trip trip);

        void Remove(Trip trip);
    }

    public class TripService : ITripService
    {
        public readonly ITripRepository _tripRepository;
        public readonly IRoleRepository _roleRepository;
        public readonly IUserRepository _userRepository;

        public TripService(ITripRepository tripRepository, IRoleRepository roleRepository, IUserRepository userRepository)
        {
            _tripRepository = tripRepository;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public List<Trip> GetAll()
        {
            return _tripRepository.GetAll();
        }

        public void Add(Trip trip)
        {
            var a = new Address() { AddressLine1 = "Demutstrasse 119", City = "St.Gallen", Country = "Switzerland" };
            var r = new Role();

            _roleRepository.Add(r);

            var us = new UserSetting { BlinkBlocker = false, HighContrast = false, ScreenReader = false, TextEnlargement = false, TextReader = false, VoiceCommands = false };
            var g = new User { FirstName = "Pascal", LastName = "Egli", BirthDate = DateTime.Now, Address = a, RoleId = r.Id, UserGroup = UserGroups.Alle, /*UserSettingId = us.Id */};

            _userRepository.Add(g);

            var roles = _roleRepository.GetAll();
            var users = _userRepository.GetAll();
            
            //trip.AddressId = a.Id;
            //trip.GuideId = g.Id;

            //_tripRepository.Add(trip);
        }

        public void Remove(Trip trip)
        {
            _tripRepository.Delete(trip);
        }
    }
}
