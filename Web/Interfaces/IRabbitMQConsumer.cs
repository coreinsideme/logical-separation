namespace LogicalSeparation.Web.Interfaces
{
    public interface IRabbitMQConsumer
    {
        void Register();
        void Unregister();
    }
}
