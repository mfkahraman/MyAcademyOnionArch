using Onion.Application.Interfaces;
using Onion.Domain.Entities;

namespace Onion.Application.Features.CQRS.Handlers
{
    public class DeleteCategoryCommandHandler(IRepository<Category> repository,
                                              IUnitOfWork unitOfWork)
    {
        public async Task<bool> Handle(Guid id)
        {
            await repository.DeleteAsync(id);
            return await unitOfWork.SaveChangesAync();
        }
    }
}
