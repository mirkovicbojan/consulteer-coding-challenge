
using MainAPI.Context;
using MainAPI.Models;
using MainAPI.Repository.Interfaces;

namespace MainAPI.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private AppDbContext _dbContext;

        public RoleRepository(AppDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}