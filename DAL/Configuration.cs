using Microsoft.Extensions.DependencyInjection;

using LogicalSeparation.DAL.Repositories;
using LogicalSeparation.DAL.Interfaces;

namespace LogicalSeparation.DAL
{
    internal static class Configuration
    {
        internal static void ConfigureDALServices(this ServiceCollection services)
        {
            services
                .AddSingleton<ICartRepository, CartRepository>();
        }
    }
}
