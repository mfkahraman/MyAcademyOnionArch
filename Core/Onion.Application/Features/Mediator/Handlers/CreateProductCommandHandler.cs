using AutoMapper;
using MediatR;
using Onion.Application.Features.Mediator.Commands;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;

namespace Onion.Application.Features.Mediator.Handlers
{
    public class CreateProductCommandHandler(IRepository<Product> repository, IMapper mapper)
        : IRequestHandler<CreateProductCommand, bool>
    {
        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Product>(request);
            try
            {
                await repository.CreateAsync(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
