using GuideMeApp.Shared.Models;
using GuideMeApp.Shared.Repositories;

namespace GuideMeApp.Shared.Services
{
    public interface IRoleService
    {
        public void Add(Role role);

        public List<Role> GetAll();
    }
    public class RoleService : IRoleService
    {
        public readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public void Add(Role r)
        {
            _roleRepository.Add(r);
        }

        public List<Role> GetAll()
        {
            return _roleRepository.GetAll();
        }
    }
}
