using GuideMeApp.Shared.Data;
using GuideMeApp.Shared.Models;

namespace GuideMeApp.Shared.Repositories
{
    public interface IUserSettingRepository : IGenericRepository<UserSetting>
    {

    }

    public class UserSettingRepository : GenericRepository<UserSetting>, IUserSettingRepository
    {
        public UserSettingRepository(LocalDbContext context) : base(context)
        {

        }
    }
}
