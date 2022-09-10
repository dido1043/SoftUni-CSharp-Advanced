using System;
using System.Collections.Generic;

namespace T04.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    var lastOpening = stack.Pop();

                    var formula = i - lastOpening + 1;
                    Console.WriteLine(input.Substring(lastOpening, formula));
                }
            }
        }
    }
}
