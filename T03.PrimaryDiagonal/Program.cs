using System;

namespace T03.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n,n];

            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine().Split();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = int.Parse(currentRow[col]);
                }
            }

            int sum = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; ++col)
                {   
                    sum+=matrix[row, col];
                    row++;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
