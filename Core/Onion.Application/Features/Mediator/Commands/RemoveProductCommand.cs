using MediatR;

namespace Onion.Application.Features.Mediator.Commands
{
    public record RemoveProductCommand(Guid Id) : IRequest<bool>;
}
