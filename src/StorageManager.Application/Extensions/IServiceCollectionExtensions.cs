using Microsoft.Extensions.DependencyInjection;

using StorageManager.Infrastructure.Extensions;

namespace StorageManager.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IServiceCollectionExtensions).Assembly));
            services.RegisterInfrastructureLayer();
            return services;
        }
    }
}
