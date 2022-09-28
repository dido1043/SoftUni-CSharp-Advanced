using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isWithUpperCase = x => char.IsUpper(x[0]);

            Console.WriteLine(String.Join("\r\n",
                Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Where(x => isWithUpperCase(x))
                ));
        }
    }
}
