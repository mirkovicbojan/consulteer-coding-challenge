
using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<User> GetAll();

        public User GetOne(Guid id);

        public User Save(UserPostDTO obj);

        public User CredentialCheck(string email, string password);
    }
}