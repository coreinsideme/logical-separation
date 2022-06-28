using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using NSwag.AspNetCore.Middlewares;

using LogicalSeparation.BLL;
using LogicalSeparation.BLL.Services;
using LogicalSeparation.BLL.Interfaces;


namespace LogicalSeparation
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.ConfigureBLLServices();

            builder.Services
                .AddSingleton<ICartService, CartService>();
            
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

            app.Run();
        }
    }
}
