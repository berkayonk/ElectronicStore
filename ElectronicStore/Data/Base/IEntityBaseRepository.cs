using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ElectronicStore.Data.Base
{
    public interface IEntityBaseRepository<T> where T: class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] expressions);
        Task<T> GetIDAsync(int id);
        Task addAsync(T entity);
        Task updateAsync(int id, T entity);
        Task deleteAsync(int id);
    }
}
