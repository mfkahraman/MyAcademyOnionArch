using AutoMapper;
using MediatR;
using Onion.Application.Features.Mediator.Commands;
using Onion.Application.Features.Mediator.Results;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;

namespace Onion.Application.Features.Mediator.Handlers
{
    public class CreateProductCommandHandler(IRepository<Product> repository, IMapper mapper, IUnitOfWork unitOfWork)
        : IRequestHandler<CreateProductCommand, GetProductQueryResult>
    {
        public async Task<GetProductQueryResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Product>(request);
            await repository.CreateAsync(product);
            await unitOfWork.SaveChangesAync();
            return mapper.Map<GetProductQueryResult>(product);
        }
    }
}
