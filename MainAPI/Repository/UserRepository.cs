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
    }
}