using AutoMapper;
using MediatR;
using Onion.Application.Features.Mediator.Queries;
using Onion.Application.Features.Mediator.Results;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;

namespace Onion.Application.Features.Mediator.Handlers
{
    public class GetProductByIdQueryHandler(IRepository<Product> repository, IMapper mapper) : IRequestHandler<GetProductByIdQuery, GetProductQueryResult>
    {
        public async Task<GetProductQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await repository.GetByIdAsync(request.Id);
            if (product is null)
            {
               throw new KeyNotFoundException($"Product with ID {request.Id} not found.");
            }
            return mapper.Map<GetProductQueryResult>(product);
        }
    }
}
