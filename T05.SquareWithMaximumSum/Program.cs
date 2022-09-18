using System;
using System.Linq;

namespace T05.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(", ");

            int rows = int.Parse(sizes[0]);
            int cols = int.Parse(sizes[1]);

            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int maxSum = 0;

            int startRow = 0;
            int startCol = 0;
            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int sum = 0;
                    sum += matrix[row, col];
                    sum += matrix[row + 1, col];
                    sum += matrix[row, col + 1];
                    sum += matrix[row+1, col + 1];

                    if (sum > maxSum)
                    {
                        startRow = row;
                        startCol = col;
                        maxSum = sum;
                    }
                    //Console.WriteLine(maxSum);
                }
            }

            Console.WriteLine($"{matrix[startRow,startCol]} " +
                ($"{matrix[startRow , startCol+ 1]} \n" +
                $"{matrix[startRow+1, startCol]} " +
                $"{matrix[startRow + 1, startCol + 1]} \n"));
                
            Console.WriteLine(maxSum);
        }
    }
}
