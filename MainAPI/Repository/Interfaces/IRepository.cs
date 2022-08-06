namespace MainAPI.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T GetById(Guid? id);

        T Save(T obj);

        T Edit(T obj);

        void Delete(T obj);
    }
}