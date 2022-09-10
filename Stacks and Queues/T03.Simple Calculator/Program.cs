using System;
using System.Collections.Generic;

namespace T03.Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                stack.Push(input[i]);
            }
            while (stack.Count > 1)
            {
                var leftNum = int.Parse(stack.Pop());
                var sign = stack.Pop();
                var rightNum = int.Parse(stack.Pop());

                if (sign == "+")
                {
                    stack.Push((leftNum + rightNum).ToString());
                }
                else if (sign == "-")
                {
                    stack.Push((leftNum - rightNum).ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
