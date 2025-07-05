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
        var connection = factory.CreateConnection(); // ✅ await it
        var channel = connection.CreateModel(); // ✅ works fine


        // Declare queue asynchronously
        channel.QueueDeclare(
           queue: "letterbox",
           durable: false,
           exclusive: false,
           autoDelete: false,
           arguments: null
       );

        var messageId = 0;
        while (true)
        { 
            messageId++;
            var publishingTime = new Random().Next(1000, 2000);
            Console.WriteLine(" [x] Publishing message...");
            var message = "Hello, RabbitMQ!  with ID: " + messageId;
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                exchange: "",
                routingKey: "letterbox",
                mandatory: false,
                basicProperties: null,
                body: body
            );
            Console.WriteLine(" [x] Sent {0}", message);
            Task.Delay(publishingTime).Wait(); // Simulate publishing time
        }
        // Publish message synchronously

    }
}
