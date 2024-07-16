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

        List<Trip> GetUpcommingTripsByUser(int userId);
    }

    public class TripService : ITripService
    {
        public readonly ITripRepository _tripRepository;

        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public List<Trip> GetAll()
        {
            return _tripRepository.GetAll();
        }

        public void Add(Trip trip)
        {
            _tripRepository.Add(trip);
        }

        public void Remove(Trip trip)
        {
            _tripRepository.Delete(trip);
        }

        public List<Trip> GetUpcommingTripsByUser(int userId)
        {
            return _tripRepository.GetUpcommingTripsByUserId(userId);
        }
    }
}
