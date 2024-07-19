using GuideMeApp.Shared.Models;
using GuideMeApp.Shared.Repositories;

namespace GuideMeApp.Shared.Services
{
    public interface IUserService
    {
        Task AddAsync(User user);

        Task UpdateAsync(User user);

        Task<List<User>> GetAllAsync();

        Task<User?> GetByIdAsync(int id);
    }

    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }
    }
}
