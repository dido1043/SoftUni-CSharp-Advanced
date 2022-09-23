using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading;
namespace T02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            Dictionary<string, List<decimal>> dict = new Dictionary<string, List<decimal>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ");
                
                if (!dict.ContainsKey(input[0]))
                {
                    dict.Add(input[0], new List<decimal>());
                }
                dict[input[0]].Add(decimal.Parse(input[1]));
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> { String.Join(" ",item.Value)} (avg: {item.Value.Average():f2})");
            }
        }
    }
}
