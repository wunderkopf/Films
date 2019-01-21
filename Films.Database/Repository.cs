using System.Collections.Generic;

namespace Films.Database
{
    public interface IRepository<T> where T : IBaseEntity
    {
        IEnumerable<T> Get();
        T FindById(int id);
        void Insert(ICollection<T> entities);
        void Update(T entity);
        void Delete(int id);
    }
}
