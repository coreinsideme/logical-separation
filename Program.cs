using System;
using Microsoft.Extensions.DependencyInjection;

using LogicalSeparation.BLL;
using LogicalSeparation.BLL.Services;
using LogicalSeparation.BLL.Interfaces;
using LogicalSeparation.BLL.Dtos;


namespace LogicalSeparation
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.ConfigureBLLServices();
            var cartService = services
                .AddSingleton<ICartService, CartService>()
                .BuildServiceProvider()
                .GetService<ICartService>();

            // Do something with service
   //         cartService.Create(1);
   //         cartService.AddItem(1, new CartItemDto { Id = 1, Name = "Mug", Price = 5, Quantity = 1 });
   //         var items = cartService.GetItems(1);
			//foreach (var item in items)
			//{
   //             Console.Write($"Item: id: {item.Id}, name: {item.Name}, price: {item.Price}, quantity: {item.Quantity}, image: {item.Image}");
   //         }
   //         Console.ReadKey();
        }
    }
}
