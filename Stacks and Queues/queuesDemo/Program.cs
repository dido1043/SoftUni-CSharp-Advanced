using System;
using System.Collections.Generic;
namespace queuesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            Console.WriteLine(String.Join(", ", queue));
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(String.Join(", ", queue));
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(String.Join(", ", queue));
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(String.Join(", ", queue));

        }
    }
}
