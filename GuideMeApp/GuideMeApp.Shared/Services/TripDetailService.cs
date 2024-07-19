using GuideMeApp.Shared.Models;
using GuideMeApp.Shared.Repositories;

namespace GuideMeApp.Shared.Services
{
    public interface ITripDetailService
    {
        Task<List<TripDetail>> GetBookedTripsByUserId(int userId);

        Task RemoveAsync(TripDetail tripDetail);
    }

    public class TripDetailService : ITripDetailService
    {
        readonly ITripDetailRepository _tripDetailRepository;

        public TripDetailService(ITripDetailRepository tripDetailRepository)
        {
            _tripDetailRepository = tripDetailRepository;
        }

        public async Task RemoveAsync(TripDetail tripDetail)
        {
            await _tripDetailRepository.RemoveAsync(tripDetail);
        }

        public async Task<List<TripDetail>> GetBookedTripsByUserId(int userId)
        {
            return await _tripDetailRepository.GetBookedTripsByUserIdAsync(userId);
        }
    }
}
