using System;
using System.Linq;

namespace t3.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = sizes[0];
            int cols = sizes[1];
            int[,] matrix = new int[rows,cols];
            for (int row = 0; row < rows; row++)
            {
                int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row,col] = input[col];
                }
            }

            int maxSum = int.MinValue;
            int startRow = 0;
            int startCol = 0;
            for (int row = 0; row < rows - 2 ; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int sum = 0;
                    sum += matrix[row,col];
                    sum += matrix[row, col+1];
                    sum += matrix[row, col+2];

                    sum += matrix[row+1, col];
                    sum += matrix[row+1, col+1];
                    sum += matrix[row+1, col+2];

                    sum += matrix[row +2,col];
                    sum += matrix[row+2, col+1];
                    sum += matrix[row+2,col+2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        startRow = row;
                        startCol = col;
                    }
                    //Console.WriteLine(sum);
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = startRow; row < startRow + 3; row++)
            {
                for (int col = startCol; col < startCol + 3; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }

            
        }
    }
}
