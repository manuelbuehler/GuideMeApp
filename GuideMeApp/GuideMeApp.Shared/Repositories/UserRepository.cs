using GuideMeApp.Shared.Data;
using GuideMeApp.Shared.Models;

namespace GuideMeApp.Shared.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }

    public class UserRepository : GenericRepository<User> , IUserRepository
    {
        public UserRepository(LocalDbContext context) : base(context) 
        { 
            
        }
    }
}
