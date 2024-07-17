// https://medium.com/nacressoftware/generic-repository-pattern-with-c-and-entity-framework-724ffef365a7
using GuideMeApp.Shared.Data;
using GuideMeApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GuideMeApp.Shared.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public readonly LocalDbContext _context;
        public DbSet<T> entity => _context.Set<T>();

        public GenericRepository(LocalDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await this.entity.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            this.entity.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this.entity.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var entity = await _context.FindAsync<T>(id);
            return entity;
        }
    }
}
