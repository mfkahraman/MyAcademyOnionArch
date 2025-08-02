using AutoMapper;
using Onion.Application.Features.CQRS.Commands;
using Onion.Application.Features.CQRS.Results;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;

namespace Onion.Application.Features.CQRS.Handlers
{
    public class CreateCategoryCommandHandler(IRepository<Category> repository,
                                              IMapper mapper,
                                              IUnitOfWork unitOfWork)
    {
        public async Task<GetCategoryQueryResult>  Handle(CreateCategoryCommand command)
        {
            var category = mapper.Map<Category>(command);
            await repository.CreateAsync(category);
            await unitOfWork.SaveChangesAync();
            return mapper.Map<GetCategoryQueryResult>(category);
        }
    }
}
