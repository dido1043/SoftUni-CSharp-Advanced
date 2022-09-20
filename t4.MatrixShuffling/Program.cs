using System;
using System.Linq;
namespace t4.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            var commnad = Console.ReadLine();
            while (commnad != "END")
            {
                var tokens = commnad.Split(" ");
                if (tokens[0] == "swap" && tokens.Length == 5 &&
                    int.Parse(tokens[1]) <= matrix.GetLength(0) &&
                    int.Parse(tokens[1]) <= matrix.GetLength(1) &&
                    int.Parse(tokens[2]) <= matrix.GetLength(0) &&
                    int.Parse(tokens[2]) <= matrix.GetLength(1) &&
                    int.Parse(tokens[3]) <= matrix.GetLength(0) &&
                    int.Parse(tokens[3]) <= matrix.GetLength(1) &&
                    int.Parse(tokens[4]) <= matrix.GetLength(0) &&
                    int.Parse(tokens[4]) <= matrix.GetLength(1) 
                    )
                {
                    var temp = matrix[int.Parse(tokens[1]), int.Parse(tokens[2])];
                    matrix[int.Parse(tokens[1]), int.Parse(tokens[2])] = matrix[int.Parse(tokens[3]), int.Parse(tokens[4])];
                    matrix[int.Parse(tokens[3]), int.Parse(tokens[4])] = matrix[int.Parse(tokens[1]), int.Parse(tokens[2])];
                    matrix[int.Parse(tokens[3]), int.Parse(tokens[4])] = temp;
                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            Console.Write($"{matrix[row, col]} ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                commnad = Console.ReadLine();
            }
        }
    }
}
