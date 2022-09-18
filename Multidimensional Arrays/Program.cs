using System;

namespace Multidimensional_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sizes =  Console.ReadLine().Split(", ");
            int rows = int.Parse(sizes[0]);
            int cols = int.Parse(sizes[1]);
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var rowData = Console.ReadLine().Split(", ");
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(rowData[col]);
                }
            }
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sum+= matrix[row, col];
                   // Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }                                                                   
    }                                                                       
}                                                                           
