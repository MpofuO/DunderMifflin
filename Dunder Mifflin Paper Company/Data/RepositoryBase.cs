using ContosoUniversity.Data.DataAccess;
using System.Linq;
using System.Linq.Expressions;

namespace Dunder_Mifflin_Paper_Company.Data
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext context;
        public RepositoryBase(AppDbContext context)
        {
            this.context = context;
        }
        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> FindAll()
        {
            return context.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
}
