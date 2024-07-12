// https://medium.com/nacressoftware/generic-repository-pattern-with-c-and-entity-framework-724ffef365a7
using GuideMeApp.Shared.Models;

namespace GuideMeApp.Shared.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public void Add(T entity);
        public void Delete(T entity);
        public void Update(T entity);
        public List<T> GetAll();
        public T GetById(Guid id);
    }
}
