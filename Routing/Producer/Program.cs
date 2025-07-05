using System;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

class Program
{
    static async Task Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };

        // Connect asynchronously
        var connection =  factory.CreateConnection(); // ✅ await it
        var channel = connection.CreateModel(); // ✅ works fine

        channel.ExchangeDeclare(
            exchange: "routing_exchange",
            type: ExchangeType.Direct,
            durable: false,
            autoDelete: false,
            arguments: null
        );
       

        // Publish message synchronously
        var message = "Hello, RabbitMQ!";
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(
            exchange: "routing_exchange",
            routingKey: "payments", // Change to "payments" for Payments Consumer
            mandatory: false,
            basicProperties: null,
            body: body
        );

        Console.WriteLine(" [x] Sent {0}", message);
    }
}
