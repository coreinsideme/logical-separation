namespace LogicalSeparation.Web.Models
{
    internal class RabbitMQConfiguration
    {
        public static string HostName { get; set; } = "localhost";

        public static string ProductQueue { get; set; } = "Product";
    }
}
