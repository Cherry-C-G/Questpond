using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteMessage();
            Console.Read();
            ReadMessage();
            Console.Read();
         }
        static void ReadMessage()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                //channel.QueueDeclare(queue: "testq",
                //                     durable: false,
                //                     exclusive: false,
                //                     autoDelete: false,
                //                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "testq",
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
                Console.ReadLine();
            }
          
        }
        static void WriteMessage()
        {
            var connectionFactory = new ConnectionFactory() { HostName = "localhost" };

            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();
            var properties = model.CreateBasicProperties();
            properties.Persistent = false;
            byte[] messagebuffer = Encoding.Default.GetBytes("Direct Message");
            model.BasicPublish("myexchange", "1001", properties, messagebuffer);
            Console.WriteLine("Message Sent");

            Console.ReadLine();
        }


    }
}
