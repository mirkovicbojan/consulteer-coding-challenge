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
            if (retVal.Count() == 0)
            {
                return null;
            }
            return retVal;
        }

        public User GetOne(Guid id)
        {
            var retVal = _userRepository.GetById(id);

            if (retVal == null)
            {
                return null;
            }

            return retVal;
        }

        public User GetCurrentUser(string email)
        {
            var retVal = _userRepository.findByEmail(email);
            if (retVal == null)
            {
                return null;
            }

            return retVal;
        }
        
        public User Save(RegisterDTO obj)
        {
            var user = new User();
            Guid generate = System.Guid.NewGuid();
            user.Id = generate;
            user.email = obj.email;
            user.password = obj.password;
            user.username = obj.username;
            user.roleID = null;
            user.role = null;
            //Done like this for easier debugging if something goes wrong.
            return _userRepository.Save(user);
        }

        public User CredentialCheck(string email, string password)
        {
            var userLogin = _userRepository.findByEmail(email);
            if (userLogin.password != password || userLogin == null)
            {
                throw new UnauthorizedAccessException("Entered credentials are incorrect.");
            }
            return userLogin;
        }

        public bool checkAvailability(RegisterDTO obj)
        {
            var credentialsCheck = _userRepository.findByCredentials(obj.email, obj.username);
            if (credentialsCheck != null)
            {
                return false;
            }
            return true;
        }

        public User UpdateRole(UserRoleUpdateDTO obj)
        {
            var user = _userRepository.findByEmail(obj.email);
            if(user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }
            user.roleID = obj.newRoleId;
            return _userRepository.Edit(user);
        }
    }
}