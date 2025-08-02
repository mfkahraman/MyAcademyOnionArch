using AutoMapper;
using MediatR;
using Onion.Application.Features.Mediator.Commands;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;

namespace Onion.Application.Features.Mediator.Handlers
{
    public class DeleteProductCommandHandler(IRepository<Product> repository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductCommand, bool>
    {
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await repository.DeleteAsync(request.Id);
            return await unitOfWork.SaveChangesAync();
        }
    }
}
