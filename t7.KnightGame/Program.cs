using System;

namespace _07.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            if (size < 3)
            {
                Console.WriteLine(0);

                return;
            }

            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string chars = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }
            int knightsRemoved = 0;
            while (true)
            {
                int countMostAttacked = 0;
                int rowMostAttacked = 0;
                int colMostaAttacked = 0;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int attacks = CountAttackedKnights(row,col,size,matrix);
                            if (countMostAttacked < attacks) 
                            {
                                countMostAttacked = attacks;
                                rowMostAttacked = row;
                                colMostaAttacked = col;
                            }
                        }
                    }
                }

                if (countMostAttacked == 0)
                {
                    break;
                }
                else
                {
                    matrix[rowMostAttacked, colMostaAttacked] = '0';
                    knightsRemoved++;
                }

            }
            Console.WriteLine(knightsRemoved);

        }

        static int CountAttackedKnights(int row, int col, int size, char[,] matrix)
        {
            int attackedKnights = 0;

            //horizontal left-up
            if (IsCellValid(row-1,col-2,size))
            {
                if (matrix[row - 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            //horizontal left-down

            if (IsCellValid(row + 1, col - 2, size))
            {
                if (matrix[row+1, col-2] == 'K')
                {
                    attackedKnights++;
                }
            }
            //horizontal right-up
            if (IsCellValid(row - 1, col + 2, size))
            {
                if (matrix[row-1, col+2] == 'K')
                {
                    attackedKnights++;
                }
            }

            //horizontal right-up

            if (IsCellValid(row + 1, col + 2, size))
            {
                if (matrix[row + 1,col+2] == 'K')
                {
                    attackedKnights++;
                }
            }
            //vertical up-left
            if (IsCellValid(row-2,col-1,size))
            {
                if (matrix[row - 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            //vertical up-right

            if (IsCellValid(row - 2, col + 1, size))
            {
                if (matrix[row - 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            //vertical down-left

            if (IsCellValid(row + 2, col - 1, size))
            {
                if (matrix[row + 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            //vertical down-right

            if (IsCellValid(row + 2, col + 1, size))
            {
                if (matrix[row + 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            return attackedKnights;
        }

        static bool IsCellValid(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }
    }
}