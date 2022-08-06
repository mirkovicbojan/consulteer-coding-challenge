using MainAPI.Models;
using MainAPI.Repository.Interfaces;
using MainAPI.Services.Interfaces;

namespace MainAPI.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

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

        public User Save(UserPostDTO obj)
        {
            var user = new User();
            user.Id = obj.Id;
            user.email = obj.email;
            user.password = obj.password;
            user.username = obj.username;
            user.roleID = obj.roleID;
            user.role = null;
            
           return _userRepository.Save(user);
        }

        public User CredentialCheck(string email, string password)
        {
            var userLogin = _userRepository.findByCredentials(email);
            if(userLogin.password != password || userLogin == null)
            {
                throw new UnauthorizedAccessException("Entered credentials are incorrect.");
            }
            return userLogin;
        }
    }
}