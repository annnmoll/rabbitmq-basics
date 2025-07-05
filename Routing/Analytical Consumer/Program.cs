using System;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

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
        // Declare queue asynchronously
        var queueName = channel.QueueDeclare( ).QueueName;
        channel.QueueBind(
            queue: queueName,
            exchange: "routing_exchange",
            routingKey: "analytics"
        );

      var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine("Analytics :- [x] Received {0}", message);
        };

        // Start consuming messages
        channel.BasicConsume(
            queue: queueName,
            autoAck: true,
            consumer: consumer
        );

    


        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();

        // Cleanup
        channel.Close();
        connection.Close();
    }
}
