using GuideMeApp.Shared.Models;
using GuideMeApp.Shared.Repositories;

namespace GuideMeApp.Shared.Services
{
    public interface IUserSettingService
    {
        Task AddAsync(UserSetting userSetting);

        Task<List<UserSetting>> GetAllAsync();
    }

    public class UserSettingService : IUserSettingService
    {
        public readonly IUserSettingRepository _userSettingRepository;

        public UserSettingService(IUserSettingRepository userSettingRepository)
        {
            _userSettingRepository = userSettingRepository;
        }

        public async Task AddAsync(UserSetting us)
        {
            await _userSettingRepository.AddAsync(us);
        }

        public async Task<List<UserSetting>> GetAllAsync()
        {
            return await _userSettingRepository.GetAllAsync();
        }
    }
}
