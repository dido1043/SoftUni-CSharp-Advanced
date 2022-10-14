using System;


namespace T02.Help_A_Mole
{
    class Mole
    {
        public int CurrentRow { get; set; }
        public int CurrentCol { get; set; }
        public int Coins { get; set; }
        public bool hasLeft { get; set; }

        public bool Ended { get; set; }
        public Mole(int row, int col)
        {
            CurrentRow = row;
            CurrentCol = col;
            Coins = 0;
            hasLeft = false;
            Ended = false;
        }

        public void Move(int size)
        { 
            string command = Console.ReadLine();
            if (command == "End")
            {
                Ended = true;
                return;
            }
            if (command == "up")
            {
                if (this.CurrentRow - 1 < 0 || this.CurrentRow - 1 >= size)
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                }
                else
                {
                    this.CurrentRow--;       
                }

            }
            else if (command == "down")
            {
                if (this.CurrentRow + 1 < 0 || this.CurrentRow + 1 >= size)
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                }
                else
                {
                    this.CurrentRow++;
                }

            }
            else if (command == "left")
            {
                if (this.CurrentCol - 1 < 0 || this.CurrentCol - 1 >= size)
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                }
                else
                {
                    this.CurrentCol--;
                }

            }
            else if (command == "right")
            {
                if (this.CurrentCol + 1 < 0 || this.CurrentCol + 1 >= size)
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                }
                else
                {
                    this.CurrentCol++;
                }

            }

            if (this.CurrentRow < 0 || this.CurrentRow == size ||
                this.CurrentCol < 0 || this.CurrentCol == size)
            {
                hasLeft = true;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = CreateMatrix(n);
            int[] indices = GetPosition(matrix);
            Mole mole = new Mole(indices[0], indices[1]);
            while (true)
            {
                if (mole.Coins >= 25)
                {
                    matrix[mole.CurrentRow, mole.CurrentCol] = 'M';
                    break;
                }
                if (mole.hasLeft)
                {
                    matrix[mole.CurrentRow, mole.CurrentCol] = 'M';
                    break;
                }
                if (mole.Ended)
                {
                    matrix[mole.CurrentRow, mole.CurrentCol] = 'M';
                    break;
                }
                mole.Move(n);
                if (matrix[mole.CurrentRow, mole.CurrentCol] <= '9' && matrix[mole.CurrentRow, mole.CurrentCol] >= '1')
                {
                    mole.Coins += int.Parse(matrix[mole.CurrentRow, mole.CurrentCol].ToString());
                    matrix[mole.CurrentRow, mole.CurrentCol] = '-';
                }
                else if (matrix[mole.CurrentRow, mole.CurrentCol] == 'S')
                {
                    mole.Coins -= 3;
                    Teleport(matrix, mole);
                }
                //matrix[mole.CurrentRow, mole.CurrentCol] = '-';
            }
            PrintOutput(mole, matrix);
        }

        static void PrintOutput(Mole mole, char[,] matrix)
        {
            if (mole.Coins < 25)
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {mole.Coins} points.");
            }
            else
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {mole.Coins} points.");
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void Teleport(char[,] matrix, Mole mole)
        {
            matrix[mole.CurrentRow, mole.CurrentCol] = '-';
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        mole.CurrentRow = row;
                        mole.CurrentCol = col;
                        matrix[row, col] = '-';
                        return;
                    }
                }
            }
        }

        static int[] GetPosition(char[,] matrix)
        {
            int[] indices = new int[2];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == 'M')
                    {
                        indices[0] = r;
                        indices[1] = c;
                        matrix[r, c] = '-';
                        return indices;
                    }
                }
            }
            return indices;
        }

        static char[,] CreateMatrix(int n)
        {
            char[,] matrix = new char[n,n];
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row,col] = input[col];
                }
            }
            return matrix;
        }
    }
}
