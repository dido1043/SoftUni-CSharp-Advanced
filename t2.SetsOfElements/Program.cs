using System;
using System.Collections.Generic;
using System.Linq;

namespace t2.SetsOfElements
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            HashSet<string> set1 = new HashSet<string>();
            HashSet<string> set2 = new HashSet<string>();
            int totalSize = sizes[0] + sizes[1];

            for (int i = 0; i < sizes[0]; i++)
            {
                string token = Console.ReadLine();
                set1.Add(token);
            }

            for (int i = 0; i < sizes[1]; i++)
            {
                set2.Add(Console.ReadLine());
            }
            set1.IntersectWith(set2);
            Console.WriteLine(String.Join(" ", set1));
        }
    }
}
