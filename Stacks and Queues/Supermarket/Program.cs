using System;
using System.Collections.Generic;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>();
            var command = Console.ReadLine();
            while (command != "End")
            {
                names.Enqueue(command);
                command = Console.ReadLine();
            }
            // Console.WriteLine(String.Join(", ", names));
            if (names.Contains("Paid"))
            {
                for (int i = 0; i <= names.Count; i++)
                {
                    var clients = names.Dequeue();
                    if (clients == "Paid")
                    {
                        break;
                    }
                    Console.WriteLine(clients);
                }
            }


            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
