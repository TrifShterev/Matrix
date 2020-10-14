using System;
using System.IO;
using System.Linq;

namespace Snake_ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var teritory = new char[n, n];
            var snakeRow = -1;
            var snakeCol = -1;
            CreateMatrifAndDefineSnakePosition(n, teritory, ref snakeRow, ref snakeCol);

            var foodEaten = 0;
            while (foodEaten!=10)
            {
                string command =Console.ReadLine();
                              

                switch (command)
                {
                    case "up":
                        snakeRow--;

                        break;
                    case "down":
                        snakeRow++;

                        break;
                    case "left":
                        snakeCol--;

                        break;
                    case "right":
                        snakeCol++;

                        break;
                }
                
                if (!CheckIndexes(teritory, snakeRow, snakeCol))
                {
                    Console.WriteLine("Game over!");
                    Console.WriteLine($"Food eaten: {foodEaten}");
                    PrintMatrix(teritory);
                    return;
                }              

                if (teritory[snakeRow,snakeCol]=='*')
                {                    
                    foodEaten++;

                }                
                else if (teritory[snakeRow, snakeCol]=='B')
                {
                    teritory[snakeRow, snakeCol] = '.';
                    for (int row = 0; row < teritory.GetLength(0); row++)
                    {
                        for (int col = 0; col < teritory.GetLength(1); col++)
                        {
                            if (teritory[row, col] == 'B')
                            {
                                snakeRow = row;
                                snakeCol = col;
                                break;
                            }
                        }
                    }
                    teritory[snakeRow, snakeCol] = '.';

                }
                if (teritory[snakeRow, snakeCol] != '.')
                {
                    teritory[snakeRow, snakeCol] = '.';
                }
            }
            teritory[snakeRow, snakeCol] = 'S';
            Console.WriteLine("You won! You fed the snake.");
            Console.WriteLine($"Food eaten: {foodEaten}");
            PrintMatrix(teritory);
        }

        private static void CreateMatrifAndDefineSnakePosition(int n, char[,] teritory, ref int snakeRow, ref int snakeCol)
        {
            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    teritory[row, col] = currentRow[col];
                    if (teritory[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                        teritory[snakeRow, snakeCol] = '.';
                    }
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
        private static bool CheckIndexes(char[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
