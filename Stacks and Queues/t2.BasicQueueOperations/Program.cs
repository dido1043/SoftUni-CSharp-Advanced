using System;
using System.Collections.Generic;
using System.Linq;

namespace t2.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = arr[0];
            int s = arr[1];
            int x = arr[2];
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(nums[i]);
            }
            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            } 

            if (queue.Count != 0)
            {
                if (queue.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
