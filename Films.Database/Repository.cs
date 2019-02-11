using System.Collections.Generic;
using System.Threading.Tasks;

namespace Films.Database
{
    public interface IRepository<T> where T : IBaseEntity
    {
        IEnumerable<T> Get();
        Task<IEnumerable<T>> GetAsync();
        T FindById(int id);
        void Insert(ICollection<T> entities);
        void Update(T entity);
        void Delete(int id);
    }
}
