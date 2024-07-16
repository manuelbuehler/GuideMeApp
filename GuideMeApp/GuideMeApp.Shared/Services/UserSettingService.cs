using GuideMeApp.Shared.Models;
using GuideMeApp.Shared.Repositories;

namespace GuideMeApp.Shared.Services
{
    public interface IUserSettingService
    {
        public void Add(UserSetting userSetting);
    }

    public class UserSettingService : IUserSettingService
    {
        public readonly IUserSettingRepository _userSettingRepository;

        public UserSettingService(IUserSettingRepository userSettingRepository)
        {
            _userSettingRepository = userSettingRepository;
        }

        public void Add(UserSetting us)
        {
            _userSettingRepository.Add(us);
        }
    }
}
