using AutoMapper;
using MediatR;
using Onion.Application.Features.Mediator.Commands;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;

namespace Onion.Application.Features.Mediator.Handlers
{
    public class UpdateProductCommandHandler(IRepository<Product> repository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<UpdateProductCommand, bool>
    {
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Product>(request);
            repository.Update(product);
            return await unitOfWork.SaveChangesAync();
        }
    }
}
