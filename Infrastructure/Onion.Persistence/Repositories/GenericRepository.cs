using Microsoft.EntityFrameworkCore;
using Onion.Application.Interfaces;
using Onion.Persistence.Context;

namespace Onion.Persistence.Repositories
{
    public class GenericRepository<TEntity>(AppDbContext context) : IRepository<TEntity>
            where TEntity : class
    {
        public async Task CreateAsync(TEntity entity)
        {
            await context.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            context.Set<TEntity>().Remove(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id)
                ?? throw new InvalidOperationException($"Entity of type {typeof(TEntity).Name} with ID {id} was not found.");
            return entity;
        }

        public void UpdateAsync(TEntity entity)
        { 
            context.Set<TEntity>().Update(entity);
        }
    }
}
