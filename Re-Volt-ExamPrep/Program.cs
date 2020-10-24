using System;
using System.IO;

namespace Re_Volt_ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int turns = int.Parse(Console.ReadLine());
            char[,] teritory = new char[n, n];
            var playerRow = -1;
            var playerCol = -1;

            for (int row = 0; row < teritory.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < teritory.GetLength(1); col++)
                {
                    teritory[row, col] = currentRow[col];
                    if (teritory[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                        teritory[row, col] = '-';
                    }
                }
            }
            string command = Console.ReadLine();
            while(turns!=0)
            {
                turns--;
               

                switch (command)
                {
                    case "up":
                        if (playerRow - 1 < 0)
                        {
                            playerRow = teritory.GetLength(0) - 1;
                            if (teritory[playerRow, playerCol] == 'T')
                            {
                                playerRow=0;
                            }
                            break;
                        }

                        playerRow--;
                        if (teritory[playerRow, playerCol] == 'T')
                        {
                            playerRow++;
                        }
                         
                        break;
                    case "down":
                        if (playerRow + 1 > teritory.GetLength(0) - 1)
                        {
                            playerRow = 0;
                            if (teritory[playerRow, playerCol] == 'T')
                            {
                                playerRow= teritory.GetLength(0) - 1;
                            }
                            break;
                        }

                        playerRow++;
                        if (teritory[playerRow, playerCol] == 'T')
                        {
                            playerRow--;
                        }
                         
                        break;
                    case "left":
                        if (playerCol - 1 < 0)
                        {
                            playerCol = teritory.GetLength(1) - 1;
                            if (teritory[playerRow, playerCol] == 'T')
                            {
                                playerCol=0;
                            }
                            break;
                        }

                        playerCol--;
                        if (teritory[playerRow, playerCol] == 'T')
                        {
                            playerCol++;
                        }
                        
                        
                        break;
                    case "right":
                        if (playerCol + 1 > teritory.GetLength(1) - 1)
                        {
                            playerCol = 0;
                            if (teritory[playerRow, playerCol] == 'T')
                            {
                                playerCol= teritory.GetLength(1) - 1;
                            }
                            break;
                        }

                        playerCol++;
                        if (teritory[playerRow, playerCol] == 'T')
                        {
                            playerCol--;
                        }                     
                         
                        
                        break;
                }
                
                
                 
                 
                if (teritory[playerRow,playerCol]=='B')
                {
                    
                    continue;
                }
                if (teritory[playerRow, playerCol] == 'F')
                {
                    teritory[playerRow, playerCol] = 'f';
                    Console.WriteLine("Player won!");
                    PrintMatrix(teritory);
                    return;
                }
                if (turns==0)
                {
                    break;
                }
                command =Console.ReadLine();
            }
            Console.WriteLine("Player lost!");
            teritory[playerRow, playerCol] = 'f';
            PrintMatrix(teritory);

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
