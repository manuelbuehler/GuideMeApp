using GuideMeApp.Shared.Data;
using GuideMeApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GuideMeApp.Shared.Repositories
{
    public interface ITripRepository : IGenericRepository<Trip>
    {
        Task<List<Trip>> GetUpcommingTripsByUserIdAsync(int userId);
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
    }
}
