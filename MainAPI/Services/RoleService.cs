using MainAPI.Models;
using MainAPI.Repository.Interfaces;
using MainAPI.Services.Interfaces;

namespace MainAPI.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public IEnumerable<Role> GetAll()
        {
            var retVal = _roleRepository.GetAll();

            if(retVal.Count() == 0)
            {
                return null;
            }

            return retVal;
        }

        public Role GetOne(Guid? id)
        {
            var retVal = _roleRepository.GetById(id);

            if(retVal == null)
            {
                throw new KeyNotFoundException("Role not found.");
            }

            return retVal;
        }

        public void DeleteOne(Guid id)
        {
            var retVal = _roleRepository.GetById(id);
            if(retVal == null)
            {
                throw new KeyNotFoundException("Role not found");
            }

            _roleRepository.Delete(retVal);
        }

        public Role UpdateOne(Role obj)
        {
            var retVal = _roleRepository.GetById(obj.Id);

            if(retVal == null)
            {
                throw new KeyNotFoundException("Role not found.");
            }

            return _roleRepository.Edit(obj);
        }

        public Role Save(Role obj)
        {
            return _roleRepository.Save(obj);
        }
    }
}