namespace Onion.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAync();
    }
}
