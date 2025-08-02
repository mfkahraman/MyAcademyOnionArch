using AutoMapper;
using Onion.Application.Features.Mediator.Commands;
using Onion.Application.Features.Mediator.Results;
using Onion.Domain.Entities;

namespace Onion.Application.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, GetProductQueryResult>();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
        }
    }
}
