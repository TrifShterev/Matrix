using System;
using System.IO;

namespace Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] teritory = new char[n, n];
            var firstPlayerRow = -1;
            var firstPlayerCol = -1;
            var secondPlayerRow = -1;
            var secondPlayerCol = -1;

            for (int row = 0; row < teritory.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < teritory.GetLength(1); col++)
                {
                    teritory[row, col] = currentRow[col];
                    if (teritory[row, col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                        
                    }
                    else if (teritory[row, col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                        
                    }
                }
            }
            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "up":
                        if (firstPlayerRow - 1 < 0)
                        {
                            firstPlayerRow = teritory.GetLength(0) - 1;
                            
                            break;
                        }

                        firstPlayerRow--;
                        break;

                    case "down":
                        if (firstPlayerRow + 1 > teritory.GetLength(0) - 1)
                        {
                            firstPlayerRow = 0;

                            break;
                        }

                        firstPlayerRow++;
                        break;
                    case "left":
                        if (firstPlayerCol - 1 < 0)
                        {
                            firstPlayerCol = teritory.GetLength(1) - 1;

                            break;
                        }

                        firstPlayerCol--;

                        break;
                    case "right":
                        if (firstPlayerCol + 1 > teritory.GetLength(1) - 1)
                        {
                            firstPlayerCol = 0;

                            break;
                        }

                        firstPlayerCol++;

                        break;

                }
                if (teritory[firstPlayerRow, firstPlayerCol] == 's')
                {
                    teritory[firstPlayerRow, firstPlayerCol] = 'x';
                    PrintMatrix(teritory);
                    return;

                }
                else
                {
                    teritory[firstPlayerRow, firstPlayerCol] = 'f';
                }

                
                switch (command[1])
                {
                    case "up":
                        if (secondPlayerRow - 1 < 0)
                        {
                            secondPlayerRow = teritory.GetLength(0) - 1;

                            break;
                        }

                        secondPlayerRow--;
                        break;

                    case "down":
                        if (secondPlayerRow + 1 > teritory.GetLength(0) - 1)
                        {
                            secondPlayerRow = 0;

                            break;
                        }

                        secondPlayerRow++;
                        break;
                    case "left":
                        if (secondPlayerCol - 1 < 0)
                        {
                            secondPlayerCol = teritory.GetLength(1) - 1;

                            break;
                        }

                        secondPlayerCol--;

                        break;
                    case "right":
                        if (secondPlayerCol + 1 > teritory.GetLength(1) - 1)
                        {
                            secondPlayerCol = 0;

                            break;
                        }

                        secondPlayerCol++;

                        break;

                }
                if (teritory[secondPlayerRow, secondPlayerCol] == 'f')
                {
                    teritory[secondPlayerRow, secondPlayerCol] = 'x';
                    PrintMatrix(teritory);
                    return;

                }
                else
                {
                    teritory[secondPlayerRow, secondPlayerCol] = 's';
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
    }
}
