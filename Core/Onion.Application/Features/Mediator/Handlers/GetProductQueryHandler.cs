using AutoMapper;
using MediatR;
using Onion.Application.Features.Mediator.Queries;
using Onion.Application.Features.Mediator.Results;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Features.Mediator.Handlers
{
    internal class GetProductQueryHandler(IRepository<Product> repository, IMapper mapper) 
        : IRequestHandler<GetProductQuery, List<GetProductQueryResult>>
    {
        public async Task<List<GetProductQueryResult>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var products = await repository.GetAllAsync();
            return mapper.Map<List<GetProductQueryResult>>(products);
        }
    }
}
