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


        // Declare queue asynchronously
         channel.QueueDeclare(
            queue: "letterbox",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

      var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(" [x] Received {0}", message);
        };

        // Start consuming messages
        channel.BasicConsume(
            queue: "letterbox",
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
