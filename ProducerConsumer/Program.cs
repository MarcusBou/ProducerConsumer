using System;
using System.Threading;

namespace ProducerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            bakery bakery = new bakery();
            Thread producer = new Thread(bakery.Producer);
            Thread consumer = new Thread(bakery.Consumer);
            producer.Start();
            consumer.Start();
        }
    }
}
