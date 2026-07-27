using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Ecom.core.Interfaces
{
    public interface IGeniricRepositire<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);

        Task<IReadOnlyList<T>> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);


        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task Deletsync(int id);

    }
}
