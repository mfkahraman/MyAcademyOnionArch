using AutoMapper;
using Onion.Application.Features.CQRS.Results;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;

namespace Onion.Application.Features.CQRS.Handlers
{
    public class GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
    {
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return mapper.Map<List<GetCategoryQueryResult>>(values);
        }
    }
}
