using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Data.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Remove(T entity);

        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task<T> FindFirstDefaultAsync(Expression<Func<T, bool>> predicate);
    }
}
