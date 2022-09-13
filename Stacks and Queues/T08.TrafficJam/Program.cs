using System;
using System.Collections.Generic;

namespace T08.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsCapacity = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();

            var command = Console.ReadLine();
            var passedCars = 0;
            var counter = 0;
            while (command != "end")
            {
                cars.Enqueue(command);
                if (command == "green")
                {

                    for (int i = 0; i < carsCapacity; i++)
                    {
                        var car = cars.Dequeue();
                        if (car != "green")
                        {
                            Console.WriteLine($"{car} passed!");
                            passedCars++;
                        }
                        
                    }
                    
                }
                counter++;
                command = Console.ReadLine();
            }
            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
