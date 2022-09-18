using System;

namespace t1.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                var currentRow = Console.ReadLine().Split(" ");
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = int.Parse(currentRow[col]);
                }
            }

            int maxLeftSum = 0;
            int maxRightSum = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    maxLeftSum += matrix[row, col];
                    row++;
                }
            }
            //Console.WriteLine(maxLeftSum);

            for (int row = 0; row < size; row++)
            {
                for (int col = size - 1  ; col >= 0; col--)
                {
                    maxRightSum += matrix[row,col];
                    row++;
                }
            }
            Console.WriteLine(Math.Abs(maxRightSum - maxLeftSum));
        }
    }
}
