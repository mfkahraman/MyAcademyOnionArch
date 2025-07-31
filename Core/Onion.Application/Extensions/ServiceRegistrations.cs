using Microsoft.Extensions.DependencyInjection;
using Onion.Application.Features.CQRS.Handlers;

namespace Onion.Application.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddApplicationExt(this IServiceCollection services)
        {
            // Fix: Use the correct overload of AddAutoMapper that accepts assemblies
            services.AddAutoMapper(cfg => { }, typeof(ServiceRegistrations).Assembly);

            services.AddScoped<GetCategoryQueryHandler>();
        }
    }
}
