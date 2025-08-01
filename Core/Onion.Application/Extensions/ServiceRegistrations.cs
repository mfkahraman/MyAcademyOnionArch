﻿using Microsoft.Extensions.DependencyInjection;
using Onion.Application.Features.CQRS.Handlers;

namespace Onion.Application.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddApplicationExt(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, typeof(ServiceRegistrations).Assembly);

            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<DeleteCategoryCommandHandler>();
        }
    }
}
