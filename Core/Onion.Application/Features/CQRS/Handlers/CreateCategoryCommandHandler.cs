using AutoMapper;
using Onion.Application.Features.CQRS.Commands;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;

namespace Onion.Application.Features.CQRS.Handlers
{
    public class CreateCategoryCommandHandler(IRepository<Category> repository,
                                              IMapper mapper,
                                              IUnitOfWork unitOfWork)
    {
        public async Task<bool>  Handle(CreateCategoryCommand command)
        {
            var category = mapper.Map<Category>(command);
            await repository.CreateAsync(category);
            return await unitOfWork.SaveChangesAync();
        }
    }
}
