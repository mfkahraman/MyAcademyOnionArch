using MediatR;
using Onion.Application.Features.Mediator.Results;

namespace Onion.Application.Features.Mediator.Commands
{
    public record CreateProductCommand(string Name, decimal Price, int Stock, Guid CategoryId) : IRequest<GetProductQueryResult>;
}
