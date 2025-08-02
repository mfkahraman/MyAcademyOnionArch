using MediatR;
using Onion.Application.Features.Mediator.Results;

namespace Onion.Application.Features.Mediator.Queries
{
    public class GetProductByIdQuery : IRequest<GetProductQueryResult>
    {
        public Guid Id { get; }
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
