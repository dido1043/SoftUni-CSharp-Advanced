using System;
using System.Linq;

namespace T06.Jagged_ArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jaggedAray = new int[n][];


            for (int row = 0; row < jaggedAray.Length; row++)
            {
                int[] cols = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                jaggedAray[row] = cols;
            }

            var command = Console.ReadLine();
            while (command != "END")
            {
                var splitedCommand = command.Split(" ");
                var operation = splitedCommand[0];
                int row = int.Parse(splitedCommand[1]);
                int col = int.Parse(splitedCommand[2]);
                int value = int.Parse(splitedCommand[3]);

                if (row >= 0 && col >= 0 &&
                    row <= jaggedAray.Length && col < jaggedAray[row].Length)
                {
                    if (operation == "Add")
                    {
                        jaggedAray[row][col] += value;
                    }
                    else if (operation == "Subtract")
                    {
                        jaggedAray[row][col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
               command = Console.ReadLine();
            }

            for (int row = 0; row < jaggedAray.Length; row++)
            {
                for (int col = 0; col < jaggedAray[row].Length; col++)
                {
                    Console.Write($"{jaggedAray[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
