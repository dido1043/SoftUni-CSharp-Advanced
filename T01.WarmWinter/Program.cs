using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.WarmWinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //hats -> Stack
            int[] hats = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)   
                .Select(int.Parse)
                .ToArray();
            Stack<int> hatsStack = new Stack<int>(hats);
            //scarfs -> Queue
            int[] scrafs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> scarfsQueue = new Queue<int>(scrafs);

            List<int> collection = new List<int> ();

            //If hat-value is lower than scarf-value - remove hat value from the Stack!!!
            //Else scarf-value + hat-value and adding result in the colection!!!
            //If hat-value and scarf-value are equal, hat-value must be removed and add 1 to scarf-value!!!
            int hatValue = 0;
            int scarfsValue = 0;

            int result = 0;
            while (true)
            {
                if (hatsStack.Count == 0 || scarfsQueue.Count == 0)
                {
                    break;
                }

                hatValue = hatsStack.Peek();//!!!
                scarfsValue = scarfsQueue.Peek();//!!!

                if (hatValue > scarfsValue)
                {
                    result = scarfsValue + hatValue;
                    collection.Add(result);
                    hatsStack.Pop();
                    scarfsQueue.Dequeue();
                }
                else if (hatValue < scarfsValue)
                {
                    hatsStack.Pop();
                    
                }
                else if (hatValue == scarfsValue)
                {
                    scarfsQueue.Dequeue();
                    hatsStack.Pop();
                    hatValue++;
                    hatsStack.Push(hatValue);
                }
                
            }
            Console.WriteLine(value: $"The most expensive set is: {collection.Max()}");
            Console.WriteLine(String.Join(" ",collection));
        }
    }
}
