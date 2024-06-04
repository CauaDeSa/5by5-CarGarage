using Model;

namespace Repository
{
    public interface IRepository<T>
    {
        public List<T> RetrieveAll();
        public bool Insert(T entity);
    }
}