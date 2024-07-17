using GuideMeApp.Shared.Data;
using GuideMeApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GuideMeApp.Shared.Repositories
{
    public interface ITripDetailRepository : IGenericRepository<TripDetail>
    {
        Task<List<TripDetail>> GetBookedTripsByUserIdAsync(int userId);
    }

    public class TripDetailRepository : GenericRepository<TripDetail>, ITripDetailRepository
    {
        public TripDetailRepository(LocalDbContext context) : base(context) 
        {
            
        }

        public async Task<List<TripDetail>> GetBookedTripsByUserIdAsync(int userId)
        {
            return await _context.TripDetails
                .Include(td => td.Trip)
                .Where(td => td.UserId == userId && td.Trip.Date > DateTime.Now)
                .ToListAsync();
        }
    }
}
