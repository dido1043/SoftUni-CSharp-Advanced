using System;
namespace T02.TheBattleOfTheFiveArmies
{

  
    internal class Program
    {
        static void Main(string[] args)
        {
            int armorOfArmy = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                matrix[row] = input;
            }

            var position = FindArmy(matrix);
            int currentRow = position[0];
            int currentCol = position[1];

            bool isWin = false;
            bool isDefeat = false;
            var commands = Console.ReadLine();
            while (true)
            {



                armorOfArmy--;
                var tokens = commands.Split(" ");
                var command = tokens[0];
                var orcRow = int.Parse(tokens[1]);
                var orcCol = int.Parse(tokens[2]);
                if (IsValid(matrix, orcRow, orcCol))
                {
                    matrix[orcRow][orcCol] = 'O';
                }
                switch (command)
                {
                    case "up":
                        if (IsValid(matrix, currentRow - 1, currentCol))
                        {
                            matrix[currentRow][currentCol] = '-';
                            currentRow--;
                        }
                        else
                        {
                            armorOfArmy--; 
                        }
                        break;
                    case "down":
                        if (IsValid(matrix, currentRow + 1, currentCol))
                        {
                            matrix[currentRow][currentCol] = '-';
                            currentRow++;
                        }
                        else
                        { 
                            armorOfArmy--; 
                        }
                        break ;
                    case "left":
                        if (IsValid(matrix, currentRow, currentCol - 1))
                        {
                            matrix[currentRow][currentCol] = '-';
                            currentCol--;
                        }
                        else
                        { 
                            armorOfArmy--; 
                        }
                        break;
                    case "right":
                        if (IsValid(matrix, currentRow, currentCol + 1))
                        {
                            matrix[currentRow][currentCol] = '-';
                            currentCol++;
                        }
                        else
                        {
                            armorOfArmy--;
                        }
                        break;
                }
                if (matrix[currentRow][currentCol] == 'M')
                {
                    matrix[currentRow][currentCol] = '-';
                    isWin = true;
                    break;
                    
                }
                if (matrix[currentRow][currentCol] == 'O')
                {
                    armorOfArmy -= 2;
                }
                if (armorOfArmy <= 0)
                {
                    matrix[currentRow][currentCol] = 'X';
                    isDefeat = true;
                    break;
                }
                commands = Console.ReadLine();
            }
            if(isWin)
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armorOfArmy}");
            else if(isDefeat)
                Console.WriteLine($"The army was defeated at {currentRow};{currentCol}.");
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                Console.WriteLine(String.Join("", matrix[r]));
            }
        }

        private static int[] FindArmy(char[][] matrix)
        {
            int[] result = new int[2];
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'A')
                    {
                        result[0] = row;
                        result[1] = col;
                    }
                }
            }
            return result;
        }

        private static bool IsValid(char[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && row < matrix[row].Length;
        }
    }
}

