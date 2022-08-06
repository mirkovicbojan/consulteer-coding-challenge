using MainAPI.Models;

namespace MainAPI.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public User findByCredentials(string credential);
    }
}