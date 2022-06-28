using Microsoft.Extensions.DependencyInjection;

using LogicalSeparation.DAL.Repositories;
using LogicalSeparation.DAL.Interfaces;

namespace LogicalSeparation.DAL
{
    internal static class Configuration
    {
        internal static void ConfigureDALServices(this IServiceCollection services)
        {
            services
                .AddSingleton<ICartRepository, CartRepository>();
        }
    }
}
