using MainAPI.Models;
using MainAPI.Repository.Interfaces;
using MainAPI.Services.Interfaces;

namespace MainAPI.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAll()
        {
            var retVal = _userRepository.GetAll();
            if(retVal.Count() == 0)
            {
                return null;
            }
            return retVal;
        }

        public User GetOne(Guid id)
        {
            var retVal = _userRepository.GetById(id);

            if(retVal == null)
            {
                return null;
            }

            return retVal;
        }

        public User Save(User obj)
        {
           return _userRepository.Save(obj);
        }
    }
}