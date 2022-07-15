using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using NSwag.AspNetCore.Middlewares;

using LogicalSeparation.BLL;
using LogicalSeparation.BLL.Services;
using LogicalSeparation.BLL.Interfaces;
using LogicalSeparation.Web.Interfaces;
using LogicalSeparation.Web.Services;
using LogicalSeparation.Web.Extensions;

namespace LogicalSeparation
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.ConfigureBLLServices();

            builder.Services
                .AddSingleton<ICartService, CartService>()
                .AddSingleton<IRabbitMQConsumer, PriceChangeConsumer>();
            
            builder.Services.AddMvc();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerDocument();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseRabbitConsumer();

            app.Run();
        }
    }
}
