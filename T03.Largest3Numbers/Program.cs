using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> numbers = new List<int>();

            int[] sortedArr =Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(n=>n)
                .ToArray();

            Console.Write(String.Join(" ", sortedArr.Take(3)));
           
        }
    }
}
