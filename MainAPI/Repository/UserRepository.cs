using MainAPI.Context;
using MainAPI.Models;
using MainAPI.Repository.Interfaces;

namespace MainAPI.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private UserDbContext _dbContext;

        public UserRepository(UserDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}