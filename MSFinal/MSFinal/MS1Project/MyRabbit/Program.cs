using EasyNetQ;
using EasyNetQ.Topology;
using System;

namespace MyRabbit
{
    class Program
    {
        static void Main(string[] args)
        {
            //var bus = RabbitHutch.CreateBus("host=localhost");
            // bus.PubSub.Publish<string>("dddd");
            // bus.PubSub.SubscribeAsync<string>(
            //        "my_subscription_id", msg => Console.WriteLine(msg)
            //    );
           // PublishTest();
            Console.WriteLine("Hello World!");
        }
        //public static void PublishTest()
        //{
        //    var advancedBus = RabbitHutch.CreateBus("host=localhost;virtualHost=Test;username=guest;password=guest;").Advanced;
        //    var routingKey = "SimpleMessage";

        //    // declare some objects
        //    var queue = advancedBus.QueueDeclare("Q.TestQueue.SimpleMessage");
        //    var exchange = advancedBus.ExchangeDeclare("E.TestExchange.SimpleMessage", ExchangeType.Direct);
        //    var binding = advancedBus.Bind(exchange, queue, routingKey);

        //    var message = new SimpleMessage() { Test = "HELLO" };
        //    for (int i = 0; i < 100; i++)
        //    {
        //        advancedBus.Publish(exchange, routingKey, true, false, new Message<SimpleMessage>(message));
        //    }
        //    advancedBus.Dispose();
        //}
    }
    class SimpleMessage
    {
        public string Test { get; set; }
    }
}
