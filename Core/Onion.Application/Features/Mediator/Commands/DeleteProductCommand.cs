using MediatR;

namespace Onion.Application.Features.Mediator.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }
    }
}
