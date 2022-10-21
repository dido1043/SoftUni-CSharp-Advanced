using System;

namespace T02.PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int size = 8;

            char[,] matrix = new char[size, size];

            int blackR = 0;
            int blackC = 0;
            int whiteR = 0;
            int whiteC = 0;
            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row,col] == 'w')
                    {
                        whiteR = row;
                        whiteC = col;
                    }
                    if (matrix[row, col] == 'b')
                    {
                        blackR = row;
                        blackC = col;
                    }
                }
            }
            bool isWhite = true;

            while (true)
            {
                if (isWhite)
                {
                    if (IsValid(matrix, whiteR - 1, whiteC - 1) && matrix[whiteR - 1, whiteC - 1] == 'b')
                    {
                        whiteR--;
                        whiteC--;
                        Console.WriteLine($"Game over! White capture on {(char)(whiteC + 97)}{8 - whiteR}.");
                        return;
                    }
                    //if (IsValid(matrix, whiteR - 1, whiteC))
                    //{ 
                        whiteR--;
                        matrix[whiteR, whiteC] = 'w';

                        if (whiteR == 0)
                        {
                            Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char) (whiteC + 97)}{matrix.GetLength(0)}.");
                            return;
                        }
                   // }
                }
                else
                {
                    if (IsValid(matrix, blackR + 1, blackC - 1) && matrix[blackR + 1, blackC - 1] == 'w')
                    {
                        blackR++;
                        blackC--;

                        Console.WriteLine($"Game over! Black capture on {(char)(blackC + 97)}{8 - blackR}.");
                        return;
                    }
                    //if (IsValid(matrix, blackR + 1, blackC))
                    //{
                        blackR++;
                        matrix[blackR, blackC] = 'b';

                        if (blackR == matrix.GetLength(0))
                        {
                            Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(blackC + 97)}{matrix.GetLength(0)}.");
                            return;
                        }
                    //}
                }
                isWhite = !isWhite;
            }
        }

        private static bool IsValid(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && row < matrix.GetLength(1);
        }
    }
}
