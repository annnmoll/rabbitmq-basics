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


        // Declare queue asynchronously
       channel.ExchangeDeclare(
            exchange: "pubsub",
            type: ExchangeType.Fanout,
            durable: false,
            autoDelete: false,
            arguments: null
        );
        // Publish message synchronously
        var message = "Hello, All Subscribers!";
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(
            exchange: "pubsub",
            routingKey: "",
            mandatory: false,
            basicProperties: null,
            body: body
        );

        Console.WriteLine(" [x] Sent {0}", message);
    }
}
