using GuideMeApp.Shared.Data;
using GuideMeApp.Shared.Models;

namespace GuideMeApp.Shared.Repositories
{
    public interface ITripRepository : IGenericRepository<Trip>
    {
        List<Trip> GetUpcommingTripsByUserId(int userId);
    }

    public class TripRepository : GenericRepository<Trip>, ITripRepository
    {
        public TripRepository(LocalDbContext context) : base(context)
        {

        }

        public List<Trip> GetUpcommingTripsByUserId(int userId)
        {
            return _context.Trips.Where(t => t.GuideId == userId && t.Date > DateTime.Now).ToList();
        }
    }
}
