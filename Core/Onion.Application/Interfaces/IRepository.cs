namespace Onion.Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task CreateAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
    }
}
