using GuideMeApp.Shared.Models;
using GuideMeApp.Shared.Repositories;

namespace GuideMeApp.Shared.Services
{
    public interface ITripService
    {
        Task<List<Trip>> GetAllAsync();

        Task AddAsync(Trip trip);

        Task RemoveAsync(Trip trip);

        Task<List<Trip>> GetUpcommingTripsByUserId(int userId);

        Task<List<Trip>> GetUpcommingTrips();
    }

    public class TripService : ITripService
    {
        public readonly ITripRepository _tripRepository;

        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<List<Trip>> GetAllAsync()
        {
            return await _tripRepository.GetAllAsync();
                
        }

        public async Task AddAsync(Trip trip)
        {
            await _tripRepository.AddAsync(trip);
        }

        public async Task RemoveAsync(Trip trip)
        {
            await _tripRepository.RemoveAsync(trip);
        }

        public async Task<List<Trip>> GetUpcommingTripsByUserId(int userId)
        {
            return await _tripRepository.GetUpcommingTripsByUserIdAsync(userId);
        }

        public async Task<List<Trip>> GetUpcommingTrips()
        {
            return await _tripRepository.GetUpcommingTripsAsync();
        }
    }
}
