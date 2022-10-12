using System;
using System.Collections.Concurrent;

namespace Armory
{
    public class Officer
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Coins { get; set; }

        public bool hasLeftArmory { get; set; }

        public Officer(int row,int col)
        {
            Row = row;
            Col = col;
            Coins = 0;
            hasLeftArmory = false;
        }
        public void Move(int matrixSize)
        {
            string command = Console.ReadLine();

            if (command == "up")
            {
                this.Row--;
            }
            else if (command == "down")
            {
                this.Row++;
            }
            else if (command == "left")
            {
                this.Col--;
            }
            else if (command == "right")
            {
                this.Col++;
            }


            if (this.Row < 0 || this.Row == matrixSize ||
                this.Col < 0 || this.Col == matrixSize)
            {
                this.hasLeftArmory = true;
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = GetMatrix(n);
            int[] currentIndices = GetIndices(matrix);
            Officer officer = new Officer(currentIndices[0], currentIndices[1]);

            while (officer.Coins < 65)
            {
                officer.Move(n);
                if (officer.hasLeftArmory)
                {
                    break;
                }
                if (matrix[officer.Row, officer.Col] >= '1' && matrix[officer.Row, officer.Col] <= '9')
                {
                    officer.Coins += int.Parse(matrix[officer.Row, officer.Col].ToString());
                    matrix[officer.Row, officer.Col] = '-';
                }
                else if (matrix[officer.Row, officer.Col]  == 'M')
                {
                    Teleport(officer, matrix);
                }
            }
            PrintOutput(matrix, officer);
        }

        static void PrintOutput(char[,] matrix, Officer officer)
        {
            if (officer.hasLeftArmory)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
                matrix[officer.Row, officer.Col] = 'A';
            }
            Console.WriteLine($"The king paid {officer.Coins} gold coins.");
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }
        }

        static void Teleport(Officer officer, char[,] matrix)
        {
            matrix[officer.Row, officer.Col] = '-';
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'M')
                    {
                        officer.Row = row;
                        officer.Col = col;
                        matrix[row, col] = '-';
                        return;
                    }
                }
            }
        }

        static int[] GetIndices(char[,] matrix)
        {
            int[] indices = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'A')
                    {
                        indices[0] = row;
                        indices[1] = col;
                        matrix[row, col] = '-';
                        return indices;
                    }
                }
            }
            return indices;
        }

        static char[,] GetMatrix(int size)
        {
            char[,] matrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            return matrix;
        }
    }
}
