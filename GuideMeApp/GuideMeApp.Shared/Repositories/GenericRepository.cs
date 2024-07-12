using GuideMeApp.Shared.Data;
using GuideMeApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GuideMeApp.Shared.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public readonly LocalDbContext _context;
        public DbSet<T> entity => _context.Set<T>();

        public GenericRepository(LocalDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            this.entity.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            this.entity.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return this.entity.ToList();
        }

        public T GetById(Guid id)
        {
            var entity = _context.Find<T>(id);
            return entity;
        }
    }
}
