using GuideMeApp.Shared.Models;
using GuideMeApp.Shared.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GuideMeApp.Shared.Services
{
    public interface ITripService
    {
        Task<List<Trip>> GetAllAsync();

        Task AddAsync(Trip trip);

        Task RemoveAsync(Trip trip);

        Task<List<Trip>> GetUpcommingTripsByUser(int userId);
    }

    public class TripService : ITripService
    {
        public readonly ITripRepository _tripRepository;

        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public Task<List<Trip>> GetAllAsync()
        {
            return _tripRepository.GetAllAsync();
        }

        public async Task AddAsync(Trip trip)
        {
            await _tripRepository.AddAsync(trip);
        }

        public async Task RemoveAsync(Trip trip)
        {
            await _tripRepository.RemoveAsync(trip);
        }

        public async Task<List<Trip>> GetUpcommingTripsByUser(int userId)
        {
            return await _tripRepository.GetUpcommingTripsByUserIdAsync(userId);
        }
    }
}
