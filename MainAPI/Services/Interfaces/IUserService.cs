using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<User> GetAll();

        public User GetOne(Guid id);

        public User Save(RegisterDTO obj);

        public User CredentialCheck(string email, string password);

        public bool checkAvailability(RegisterDTO obj);
    }
}