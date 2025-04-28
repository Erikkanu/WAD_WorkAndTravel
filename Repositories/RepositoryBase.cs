using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WAD_WorkAndTravel.Models;

namespace WAD_WorkAndTravel.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected WAT_Context Context { get; set; }

        public RepositoryBase(WAT_Context context)
        {
            Context = context;
        }

        public IQueryable<T> FindAll() => Context.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            Context.Set<T>().Where(expression).AsNoTracking();

        public void Create(T entity) => Context.Set<T>().Add(entity);

        public void Update(T entity) => Context.Set<T>().Update(entity);

        public void Delete(T entity) => Context.Set<T>().Remove(entity);
    }
}
