using MediatR;
using Onion.Application.Features.Mediator.Results;

namespace Onion.Application.Features.Mediator.Commands
{
    public record CreateProductCommand : IRequest<GetProductQueryResult>
    {
        public required string Name { get; init; }
        public decimal Price { get; init; }
        public int Stock { get; init; }
        public Guid CategoryId { get; init; }
    }
}
