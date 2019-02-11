using System.Collections.Generic;
using System.Threading.Tasks;
using Films.Services.Models;

namespace Films.Services
{
    public interface IService<T> where T : IBaseModel
    {
        IEnumerable<T> Get();
        Task<IEnumerable<T>> GetAsync();
        T Get(int id);
        void Insert(ICollection<T> models);
        void Update(T model);
        void Delete(int id);
    }
}
