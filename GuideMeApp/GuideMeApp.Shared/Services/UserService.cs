using GuideMeApp.Shared.Models;
using GuideMeApp.Shared.Repositories;

namespace GuideMeApp.Shared.Services
{
    public interface IUserService
    {
        public void Add(User user);

        public List<User> GetAll();
    }

    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User u)
        {
            _userRepository.Add(u);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}
