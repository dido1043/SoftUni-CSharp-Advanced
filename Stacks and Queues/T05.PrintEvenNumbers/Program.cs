using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            List<int> list = new List<int>();
            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                queue.Enqueue(arr[i]);
            }
            
            foreach (var item in queue)
            {
                if (item % 2 == 0)
                {
                    list.Add(item);
                }  
            }
            Console.WriteLine(String.Join(", ", list));
        }
    }
}
