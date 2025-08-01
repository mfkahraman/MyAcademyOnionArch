using AutoMapper;
using Onion.Application.Features.CQRS.Commands;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;

namespace Onion.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler(IRepository<Category> repository,
                                              IMapper mapper,
                                              IUnitOfWork unitOfWork)
    {
        public async Task<bool> Handle(UpdateCategoryCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command), "Command cannot be null.");
            }
  
            var category = mapper.Map<Category>(command);
            repository.Update(category);
            return await unitOfWork.SaveChangesAync();
        }
    }
}
