using System;
using System.Linq;

namespace T02.SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var range = Console.ReadLine().Split(", ");

            int rows = int.Parse(range[0]);
            int cols = int.Parse(range[1]);

            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowData = Console.ReadLine().Split(" ");
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] =int.Parse(rowData[col]);
                }
            }
            int sum = 0;
            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);
                sum = 0;    
            }
        }
    }
}
