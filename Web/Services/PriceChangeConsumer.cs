using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

using LogicalSeparation.Web.Interfaces;
using LogicalSeparation.Web.Models;
using LogicalSeparation.BLL.Interfaces;
using LogicalSeparation.BLL.Dtos;

namespace LogicalSeparation.Web.Services
{
    public class PriceChangeConsumer : IRabbitMQConsumer
    {
        private readonly ICartService _cartService;
        private IConnection _connection;
        private IModel _channel;

        public PriceChangeConsumer(ICartService cartService)
        {
            this._cartService = cartService;
        }

        public void Register()
        {
            var connectionFactory = new ConnectionFactory() { HostName = RabbitMQConfiguration.HostName };
            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: RabbitMQConfiguration.ProductQueue,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var priceChangeDto = JsonSerializer.Deserialize<PriceChangeModel>(message);
                _cartService.UpdateItemPrice(priceChangeDto.Name, priceChangeDto.Price);
            };

            _channel.BasicConsume(queue: RabbitMQConfiguration.ProductQueue,
                                 autoAck: true,
                                 consumer: consumer);
        }

        public void Unregister()
        {
            _channel.Dispose();
            _connection.Close();
        }
    }
}
