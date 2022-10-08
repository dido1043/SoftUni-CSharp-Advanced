using System;

namespace CustomStack
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            //Console.WriteLine(stack.Count);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Peek());

            stack.ForEach(x => Console.Write(x + " "));
        }
    }
}
