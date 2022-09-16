using System;
using System.Collections.Generic;
using System.Linq;

namespace t4.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            int qty = int.Parse(Console.ReadLine());
            int[] numsArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(numsArr.Max());
            for (int i = 0; i < numsArr.Length; i++)
            {
                queue.Enqueue(numsArr[i]);
            }
            int value = 0;
            while (queue.Count > 0 && qty > 0)
            {
                qty -= value;
                if (qty < value)
                {
                    Console.WriteLine($"Orders left: {String.Join(" ", queue)}");

                    return;
                }
                value = queue.Dequeue();
            }
            Console.WriteLine("Orders complete");
        }
    }
}
