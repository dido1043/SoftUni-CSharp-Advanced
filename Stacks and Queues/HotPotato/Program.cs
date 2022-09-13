using System;
using System.Collections.Generic;

namespace HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            
            Queue<string> queue = new Queue<string>(names);
            var tosses = 1;
            while (queue.Count > 1)
            {
                var currentKid = queue.Dequeue();
                if (tosses == n)
                {
                    Console.WriteLine($"Removed {currentKid}");
                    tosses = 1;
                    continue;
                }
                queue.Enqueue(currentKid);
                tosses++;
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
