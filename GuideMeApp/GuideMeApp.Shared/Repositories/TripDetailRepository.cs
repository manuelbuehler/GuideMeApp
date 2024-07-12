using GuideMeApp.Shared.Data;
using GuideMeApp.Shared.Models;

namespace GuideMeApp.Shared.Repositories
{
    public interface ITripDetailRepository : IGenericRepository<TripDetail>
    {
    }

    public class TripDetailRepository : GenericRepository<TripDetail>, ITripDetailRepository
    {
        public TripDetailRepository(LocalDbContext context) : base(context) 
        {
            
        }
    }
}
