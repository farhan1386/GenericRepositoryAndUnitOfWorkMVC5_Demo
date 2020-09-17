using DependencyInjectionUnityContainerMVC5_Demo.Data;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjectionUnityContainerMVC5_Demo.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext Context;
        public Repository(ApplicationDbContext context)
        {
            Context = context;
        }
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }
        public TEntity GetById(int? id)
        {
            return Context.Set<TEntity>().Find(id);
        }
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
    }
}