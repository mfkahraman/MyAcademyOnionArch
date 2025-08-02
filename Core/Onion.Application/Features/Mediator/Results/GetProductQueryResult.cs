using Onion.Application.Features.CQRS.Results;

namespace Onion.Application.Features.Mediator.Results
{
    public record GetProductQueryResult
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Guid CategoryId { get; set; }
    }
}
