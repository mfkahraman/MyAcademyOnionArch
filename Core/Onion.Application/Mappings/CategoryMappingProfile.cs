using AutoMapper;
using Onion.Application.Features.CQRS.Results;
using Onion.Domain.Entities;

namespace Onion.Application.Mappings
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, GetCategoryQueryResult>().ReverseMap();
        }
    }
}
