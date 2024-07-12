using GuideMeApp.Shared.Data;
using GuideMeApp.Shared.Models;

namespace GuideMeApp.Shared.Repositories
{
    public interface ITripRepository : IGenericRepository<Trip>
    {
    }

    public class TripRepository : GenericRepository<Trip>, ITripRepository
    {
        public TripRepository(LocalDbContext context) : base(context)
        {

        }
    }
}
