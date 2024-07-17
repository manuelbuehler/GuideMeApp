using GuideMeApp.Shared.Models;
using GuideMeApp.Shared.Repositories;

namespace GuideMeApp.Shared.Services
{
    public interface IRoleService
    {
        Task AddAsync(Role role);

        Task<List<Role>> GetAllAsync();
    }
    public class RoleService : IRoleService
    {
        public readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task AddAsync(Role r)
        {
            await _roleRepository.AddAsync(r);
        }

        public async Task<List<Role>>GetAllAsync()
        {
            return await _roleRepository.GetAllAsync();
        }
    }
}
