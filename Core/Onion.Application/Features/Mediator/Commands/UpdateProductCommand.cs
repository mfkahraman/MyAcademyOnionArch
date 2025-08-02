using MediatR;

namespace Onion.Application.Features.Mediator.Commands
{
    public record UpdateProductCommand(Guid Id, string Name, decimal Price, int Stock, Guid CategoryId)
        : IRequest<bool>;
}
