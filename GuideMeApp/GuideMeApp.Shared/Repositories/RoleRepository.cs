using GuideMeApp.Shared.Data;
using GuideMeApp.Shared.Models;

namespace GuideMeApp.Shared.Repositories
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
    }

    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(LocalDbContext context) : base(context)
        {
        }
    }
}
