using MainAPI.Context;
using MainAPI.Models;
using MainAPI.Repository.Interfaces;

namespace MainAPI.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
        public User findByCredentials(string email, string username)
        {
            var user = _dbContext.Set<User>().Where(u => u.email == email || u.username == username).FirstOrDefault();
            /*if(user == null)
            {
                throw new KeyNotFoundException("The entered user doesn't exist.");
            }*/

            return user ?? null;
        }

        public User findByEmail(string email)
        {
            var user = _dbContext.Set<User>().Where(u => u.email == email).FirstOrDefault();
            /*if(user == null)
            {
                throw new KeyNotFoundException("The entered user doesn't exist.");
            }*/

            return user ?? null;
        }
    }
}