using AutoMapper;
using Onion.Application.Features.CQRS.Queries;
using Onion.Application.Features.CQRS.Results;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;

namespace Onion.Application.Features.CQRS.Handlers
{
    public class GetCategoryByIdQueryHandler(IRepository<Category> repository,
                                             IMapper mapper)
    {
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var category = await repository.GetByIdAsync(query.id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {query.id} not found.");
            }
            return mapper.Map<GetCategoryByIdQueryResult>(category);
        }
    }
}
