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
        
        public User findByCredentials(string credential)
        {
            var user = _dbContext.Set<User>().Where(u => u.email == credential).FirstOrDefault();
            if(user == null)
            {
                throw new KeyNotFoundException("The entered user doesn't exist.");
            }
            return user ?? null;
        }
    }
}