using System;
using System.Linq;

namespace t2._2X2SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine();
                var edited = String.Concat(currentRow.Where(c => !Char.IsWhiteSpace(c)));
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = edited[col];
                }
            }


            int counter = 0;

            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    var matrix1 = (char)matrix[row, col];
                    var matrix2 = (char)matrix[row+1, col];
                    var matrix3 = (char)matrix[row, col+1];
                    var matrix4 = (char)matrix[row+1, col+1];
                    

                    if ((char)matrix[row,col] == (char)matrix[row+1, col] &&
                        (char)matrix[row, col] == (char)matrix[row , col + 1] &&
                        (char)matrix[row, col] == (char)matrix[row + 1, col + 1])
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);

      }
    }
}
