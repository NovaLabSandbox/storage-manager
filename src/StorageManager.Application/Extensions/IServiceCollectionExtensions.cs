using Microsoft.Extensions.DependencyInjection;

using StorageManager.Application.Interfaces;
using StorageManager.Application.Services;
using StorageManager.Infrastructure.Extensions;

namespace StorageManager.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IServiceCollectionExtensions).Assembly));
            services.AddAutoMapper(typeof(IServiceCollectionExtensions).Assembly);
            services.AddScoped<ICacheService, CacheService>();
            services.RegisterInfrastructureLayer();
            return services;
        }
    }
}
