using System;
using System.Collections.Generic;
using System.Linq;

namespace t1.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = arr[0];
            int s = arr[1];
            int x = arr[2];


            int[] secondArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < n; i++)
            {

                stack.Push(secondArr[i]);
            }


            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }
            if (stack.Count != 0)
            {
                if (stack.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {                
                    Console.WriteLine(stack.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }

        }
    }
}
