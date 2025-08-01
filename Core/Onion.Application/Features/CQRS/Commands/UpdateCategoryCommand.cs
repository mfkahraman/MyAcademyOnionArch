namespace Onion.Application.Features.CQRS.Commands
{
    public record UpdateCategoryCommand(Guid id, string Name);
}
