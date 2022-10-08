using System;
using System.Collections.Generic;

namespace CustomList
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();
            //list[0] = 100;
            list.Add(1);
            //list.Add(8);
            Console.WriteLine(list[0]);
            Console.WriteLine(list.Count);
            Console.WriteLine(list.RemoveAt(0));

            list.Insert(0,9);
            list.Insert(1, 3);
            list.Insert(2, 100);

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }

            list.Swap(0, 1);
            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(list.Contains(3));
            Console.WriteLine(list.Contains(4));
        }
    }
}
