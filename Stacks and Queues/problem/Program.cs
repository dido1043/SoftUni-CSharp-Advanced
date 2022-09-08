using System;
using System.Collections.Generic;
using System.Linq;

namespace problem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < inputArr.Length; i++)
            {
                stack.Push(inputArr[i]);
            }

            var command = Console.ReadLine().ToLower();
            while (command != "end")
            {
                var tokens = command.Split(" ");
                if (tokens[0] == "add")
                {
                    stack.Push(int.Parse(tokens[1]));
                    stack.Push(int.Parse(tokens[2]));
                }
                else if (tokens[0] == "remove")
                {
                    if (stack.Count() >= int.Parse(tokens[1]))
                    {
                        for (int i = 0; i < int.Parse(tokens[1]); i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                command = Console.ReadLine().ToLower();
            }
            Console.WriteLine("Sum: " + stack.Sum());
        }
    }
}
