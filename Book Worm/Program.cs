using System;
using System.Data;
using System.IO;
using System.Linq;

namespace Book_Worm
{
    class Program
    {
        static void Main(string[] args)
        {
            var letters = Console.ReadLine().ToList();
            int size = int.Parse(Console.ReadLine());

            char[,] playGround = new char[size, size];
            var playerRow = -1;
            var playerCol = -1;

            for (int row = 0; row < playGround.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine();
                    

                for (int col = 0; col < playGround.GetLength(1); col++)
                {
                    playGround[row, col] = currentRow[col];
                    if (playGround[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                        playGround[row, col] = '-';
                    }
                }
            }
            string command;
            while ((command=Console.ReadLine())!="end")
            {
                switch (command)
                {
                    case "up":
                        playerRow--;
                        if (!CheckIndexes(playGround,playerRow,playerCol))
                        {
                            playerRow++;
                            if (letters.Any())
                            {
                                letters.RemoveAt(letters.Count-1);
                            }
                            
                            continue;
                        }
                        break;
                    case "down":
                        playerRow++;
                        if (!CheckIndexes(playGround, playerRow, playerCol))
                        {
                            playerRow--;
                            if (letters.Any())
                            {
                                letters.RemoveAt(letters.Count - 1);
                            }

                            continue;
                        }
                        break;
                    case "left":
                        playerCol--;
                        if (!CheckIndexes(playGround, playerRow, playerCol))
                        {
                            playerCol++;
                            if (letters.Any())
                            {
                                letters.RemoveAt(letters.Count - 1);
                            }

                            continue;
                        }
                        break;
                    case "right":
                        playerCol++;
                        if (!CheckIndexes(playGround, playerRow, playerCol))
                        {
                            playerCol--;
                            if (letters.Any())
                            {
                                letters.RemoveAt(letters.Count - 1);
                            }

                            continue;
                        }
                        break;
                }
                if (char.IsLetter(playGround[playerRow, playerCol]))
                {
                    var newLetter = playGround[playerRow, playerCol];
                    letters.Add(newLetter);
                    playGround[playerRow, playerCol] = '-';
                }
            }
            
            Console.WriteLine(string.Join("",letters));
            playGround[playerRow, playerCol] = 'P';
            PrintMatrix(playGround);
        }
        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] );
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
