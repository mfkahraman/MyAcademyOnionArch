namespace Onion.Application.Features.CQRS.Results
{
    public record GetCategoryByIdQueryResult
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
