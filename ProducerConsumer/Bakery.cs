using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProducerConsumer
{
    class bakery
    {
        Queue<int> CakeTray = new Queue<int>();

        public void Consumer()
        {
            while (true)
            {
                lock (CakeTray)
                {
                    while (CakeTray.Count == 0)//if caketray is empty, consume pulse and notices it waits
                    {
                        Monitor.PulseAll(CakeTray);
                        Console.WriteLine("Consumer Waits....");
                        Monitor.Wait(CakeTray);
                    }
                    Console.WriteLine("Consumer Consumes: " + CakeTray.Count);//consumes
                    CakeTray.Dequeue();
                }
                Thread.Sleep(600);

            }
                
        }


        public void Producer()
        {
            Random rnd = new Random();
            while (true)
            {
                int cake = rnd.Next(1, 6);//Create a random amount of items to go into queue
                lock (CakeTray)
                {
                    while (CakeTray.Count != 0)//if caketray is not empty producer waits for consume
                    {
                        Console.WriteLine("producer Waits...");
                        Monitor.Wait(CakeTray);
                    }
                    for (int i = 1; i <= cake; i++)//for loop adds items in this scenario its just a 1. but could be any other object
                    {
                        CakeTray.Enqueue(1);
                        Console.WriteLine("Producer produce: " + i);//writes how far in production
                        Thread.Sleep(600);
                    }
                    Monitor.PulseAll(CakeTray);//pulses costumer.
                }
            }
        }
    }
}
