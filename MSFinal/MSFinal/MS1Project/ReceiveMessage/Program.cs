using EasyNetQ;
using System;
using MS1Project;
namespace ReceiveMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.PubSub.SubscribeAsync<CustomerCreatedEvent>("my_subscription_id", Handler);
            }
            Console.Read();
            Console.WriteLine("Hello World!");
        }
        public static void Handler(CustomerCreatedEvent obj)
        {
            // 
        }

    }
}
