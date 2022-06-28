using Microsoft.Extensions.DependencyInjection;

using LogicalSeparation.BLL.Services;
using LogicalSeparation.BLL.Mappers;
using LogicalSeparation.BLL.Interfaces;
using LogicalSeparation.DAL;

namespace LogicalSeparation.BLL
{
    internal static class Configuration
    {
        internal static void ConfigureBLLServices(this IServiceCollection services)
        {
            services
                .AddSingleton<ICartService, CartService>()
                .AddSingleton<ICartMapper, CartMapper>()
                .AddSingleton<ICartItemMapper, CartItemMapper>();

            services.ConfigureDALServices();
        }
    }
}
