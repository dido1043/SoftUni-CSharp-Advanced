using System;
using System.Collections.Generic;
using System.Linq;

namespace T06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<String> queue = new Queue<string>();
            var command = Console.ReadLine();
            while (command != "End")
            {
                //queue.Enqueue(command);
                if (command == "Paid")
                {
                    while (queue.Any())
                    {
                        Console.WriteLine(queue.Dequeue());                       
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
