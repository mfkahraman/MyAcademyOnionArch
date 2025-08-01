namespace Onion.Application.Features.CQRS.Commands
{
    public record UpdateCategoryCommand(Guid Id, string Name);
}
