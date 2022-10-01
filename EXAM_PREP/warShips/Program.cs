using System;
using System.Collections.Generic;
using System.Linq;

namespace warShips
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Take input
            int n = int.Parse(Console.ReadLine());
            string[,] matrix = new string[n, n];

            int[] attacks = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int playerOneCount = 0;
            int playerTwoCount = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == "<")
                    {
                        playerOneCount++;
                    }
                    else if (matrix[row, col] == ">")
                    {
                        playerTwoCount++;
                    }
                }
            }
            int totalShips = playerOneCount + playerTwoCount;
            //For-loop on collection of cordinates
            for (int i = 0; i < attacks.Length-1; i+=2)
            {
                int rowIndex = attacks[i];
                int colIndex = attacks[i + 1];
                if (IsValid(matrix, rowIndex, colIndex))
                {
                    if (matrix[rowIndex, colIndex] == "<")
                    {
                        playerOneCount--;
                        matrix[rowIndex, colIndex] = "X";
                    }
                    else if (matrix[rowIndex, colIndex] == ">")
                    {
                        playerTwoCount--;
                        matrix[rowIndex, colIndex] = "X";
                    }
                    else if (matrix[rowIndex, colIndex] == "#")
                    {
                        //Up
                        if (IsValid(matrix, rowIndex - 1, colIndex))
                        {
                            if (matrix[rowIndex - 1, colIndex] == "<")
                            {
                                playerOneCount--;
                                matrix[rowIndex - 1, colIndex] = "X";
                            }
                            else if (matrix[rowIndex - 1, colIndex] == ">")
                            {
                                playerTwoCount--;
                                matrix[rowIndex - 1, colIndex] = "X";
                            }
                        }
                        //UpLeft
                        if (IsValid(matrix, rowIndex - 1, colIndex - 1))
                        {
                            if (matrix[rowIndex - 1, colIndex - 1] == "<")
                            {
                                playerOneCount++;
                                matrix[rowIndex - 1, colIndex - 1] = "X";
                            }
                            else if (matrix[rowIndex - 1, colIndex - 1] == ">")
                            {
                                playerTwoCount++;
                                matrix[rowIndex - 1, colIndex - 1] = "X";
                            }
                        }
                        //Up Right
                        if (IsValid(matrix, rowIndex - 1, colIndex + 1))
                        {
                            if (matrix[rowIndex - 1, colIndex + 1] == "<")
                            {
                                playerOneCount--;
                                matrix[rowIndex - 1, colIndex + 1] = "X";
                            }
                            else if (matrix[rowIndex - 1, colIndex + 1] == ">")
                            {
                                playerTwoCount--;
                                matrix[rowIndex - 1, colIndex + 1] = "X";
                            }
                        }
                        //left
                        if (IsValid(matrix, rowIndex, colIndex-1))
                        {
                            if (matrix[rowIndex, colIndex-1] == "<")
                            {
                                playerOneCount--;
                                matrix[rowIndex, colIndex-1] = "X";
                            }
                            else if (matrix[rowIndex, colIndex-1] == " >")
                            {
                                playerTwoCount--;
                                matrix[rowIndex, colIndex - 1] = "X";
                            }

                        }
                        //right
                        if (IsValid(matrix, rowIndex, colIndex + 1))
                        {
                            if (matrix[rowIndex, colIndex + 1] == "<")
                            {
                                playerOneCount--;
                                matrix[rowIndex, colIndex + 1] = "X";
                            }

                            else if (matrix[rowIndex, colIndex + 1] == ">")
                            {
                                playerTwoCount--;
                                matrix[rowIndex, colIndex + 1] = "X";
                            }
                        }
                        //down
                        if (IsValid(matrix, rowIndex + 1, colIndex))
                        {
                            if (matrix[rowIndex+ 1, colIndex ] == "<")
                            {
                                playerOneCount--;
                                matrix[rowIndex + 1, colIndex] = "X";
                            }

                            else if (matrix[rowIndex+ 1, colIndex ] == ">")
                            {
                                playerTwoCount--;
                                matrix[rowIndex + 1, colIndex] = "X";
                            }
                        }
                        //downRight

                        if (IsValid(matrix, rowIndex + 1, colIndex + 1))
                        {
                            if (matrix[rowIndex + 1, colIndex + 1] == "<")
                            {
                                playerOneCount--;
                                matrix[rowIndex + 1, colIndex + 1] = "X";
                            }

                            else if (matrix[rowIndex + 1, colIndex + 1] == ">")
                            {
                                playerTwoCount--;
                                matrix[rowIndex + 1, colIndex + 1] = "X";
                            }
                        }

                        //downLeft
                        if (IsValid(matrix, rowIndex + 1, colIndex - 1))
                        {
                            if (matrix[rowIndex + 1, colIndex - 1] == "<")
                            {
                                playerOneCount--;
                                matrix[rowIndex + 1, colIndex - 1] = "X";
                            }
                            else if (matrix[rowIndex + 1, colIndex - 1] == ">")
                            {
                                playerTwoCount--;
                                matrix[rowIndex + 1, colIndex - 1] = "X";
                            }
                        }
                    }
                }
            }

            Winner(playerOneCount, playerTwoCount,totalShips);
        }

        private static void Winner(int firstPlayerCount, int secoundPlayerCount, int total)
        {
            

            if (firstPlayerCount >0 && secoundPlayerCount > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerCount} ships left. Player Two has {secoundPlayerCount} ships left.");
                return;
            }
            if (firstPlayerCount > secoundPlayerCount)
            {
                Console.WriteLine($"Player One has won the game! {total - firstPlayerCount} ships have been sunk in the battle.");
            }
            else if (firstPlayerCount < secoundPlayerCount)
            {
                Console.WriteLine($"Player Two has won the game! {total - secoundPlayerCount} ships have been sunk in the battle.");
            }
        }

        private static bool IsValid(string[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&  col >= 0 && col < matrix.GetLength(1);
        }
    }
}
