using System.Collections.Generic;

namespace DependencyInjectionUnityContainerMVC5_Demo.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int? id);
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
