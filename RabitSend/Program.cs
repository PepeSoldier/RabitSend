using RabbitMQ.Client;
using System;
using System.Text;

namespace RabitSend
{
    internal class Program
    {
        private class Send

        {
            public static void Main()
            {
                var factory = new ConnectionFactory() { HostName = "10.10.1.4", UserName = "oneprod", Password = "c5mvmZN2kqOrVKVYFRs_XX2sVfZBVUun" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "test-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

                    string message = "dickens";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "", routingKey: "test-queue", basicProperties: null, body: body);
                    Console.WriteLine(" [x] Sent {0}", message);
                    Console.WriteLine("2PAck changes");
                }

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}