using Microsoft.Extensions.DependencyInjection;

using StorageManager.Infrastructure.Interfaces;
using StorageManager.Infrastructure.Repositories;

namespace StorageManager.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection RegisterInfrastructureLayer(this IServiceCollection services)
        {
            services.AddScoped<ISiteRepository, SiteRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            return services;
        }
    }
}
