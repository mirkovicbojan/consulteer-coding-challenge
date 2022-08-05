using MainAPI.Models;

namespace MainAPI.Services.Interfaces
{
    public interface IRoleService
    {
        public IEnumerable<Role> GetAll();

        public Role GetOne(Guid id);

        public Role Save(Role obj);

        public void DeleteOne(Guid id);

        public Role UpdateOne(Role obj);
    }
}