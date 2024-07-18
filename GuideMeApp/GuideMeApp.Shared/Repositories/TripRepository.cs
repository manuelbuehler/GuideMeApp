using GuideMeApp.Shared.Data;
using GuideMeApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GuideMeApp.Shared.Repositories
{
    public interface ITripRepository : IGenericRepository<Trip>
    {
        Task<List<Trip>> GetUpcommingTripsByUserIdAsync(int userId);

        Task<List<Trip>> GetUpcommingTripsAsync();
    }

    public class TripRepository : GenericRepository<Trip>, ITripRepository
    {
        public TripRepository(LocalDbContext context) : base(context)
        {

        }

        public async Task<List<Trip>> GetUpcommingTripsByUserIdAsync(int userId)
        {
            return await _context.Trips
                .Where(t => t.GuideId == userId && t.Date > DateTime.Now)
                .ToListAsync();
        }
        
        public async Task<List<Trip>> GetUpcommingTripsAsync()
        {
            return await _context.Trips
                .Include(t => t.Guide)
                .Where(t => t.Date > DateTime.Now)
                .ToListAsync();
        }
    }
}
