using Onion.Application.Interfaces;
using Onion.Persistence.Context;

namespace Onion.Persistence.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public async Task<bool> SaveChangesAync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
