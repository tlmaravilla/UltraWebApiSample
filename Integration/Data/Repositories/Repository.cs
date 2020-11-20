using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Integration.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Integration.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected int TakeAmount = 50;

        protected readonly DbSet<T> Entities;

        public Repository(AppDbContext dbContext)
        {
            Entities = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            Entities.Add(entity);
        }

        public void Remove(T entity)
        {
            Entities.Remove(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Entities.FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Entities.Take(TakeAmount).ToListAsync();
        }

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await Entities.Where(predicate).ToListAsync();
        }

        public async Task<T> FindFirstDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await Entities.Where(predicate).ToListAsync();
            return result.FirstOrDefault();
        }

        //public T Get(ISpecification<T> spec)
        //{
        //    return BuildQuery(spec).FirstOrDefault();
        //}

        //private IQueryable<T> BuildQuery(ISpecification<T> spec)
        //{
        //    var queryable = Entities.Where(spec.Criteria);

        //    // fetch a Queryable that includes all expression-based includes
        //    queryable = spec.Includes.Aggregate(queryable, (current, include) => current.Include(include));

        //    // modify the IQueryable to include any string-based include statements
        //    queryable = spec.IncludeStrings.Aggregate(queryable, (current, include) => current.Include(include));

        //    if (spec.Sort != null)
        //    {
        //        queryable = spec.Sort(queryable);
        //    }

        //    if (spec.SkipAmount != null)
        //    {
        //        queryable = queryable.Skip(spec.SkipAmount.Value);
        //    }

        //    if (spec.TakeAmount != null)
        //    {
        //        queryable = queryable.Take(spec.TakeAmount.Value);
        //    }

        //    return queryable;
        //}
    }
}
