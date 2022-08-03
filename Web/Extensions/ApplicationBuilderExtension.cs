using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using LogicalSeparation.Web.Services;
using LogicalSeparation.Web.Interfaces;

namespace LogicalSeparation.Web.Extensions
{
    public static class ApplicationBuilderExtension
    {
        private static IRabbitMQConsumer _consumer { get; set; }

        public static IApplicationBuilder UseRabbitConsumer(this IApplicationBuilder app)
        {
            _consumer = app.ApplicationServices.GetService<IRabbitMQConsumer>();

            var lifetime = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            lifetime.ApplicationStarted.Register(OnStarted);

            lifetime.ApplicationStopping.Register(OnStopping);

            return app;
        }

        private static void OnStarted()
        {
            //_consumer.Register();
        }

        private static void OnStopping()
        {
            //_consumer.Unregister();
        }
    }
}
