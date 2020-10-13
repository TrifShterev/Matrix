using System;
using System.IO;

namespace Bee_ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            CreateMatrix(matrix);
            var beeRow = -1;
            var beeCol = -1;

            int polinatedFlowers = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                        matrix[beeRow, beeCol] = '.';
                    }



                }
            }   

                string command = Console.ReadLine();
            while (command  != "End")
                {
                    switch (command)
                    {
                        case "up":
                            beeRow--;
                            
                            break;
                        case "down":
                            beeRow++;
                            
                            break;
                        case "left":
                            beeCol--;
                            
                            break;
                        case "right":
                            beeCol++;
                           
                            break;
                    }
                    if (CellCoordinatesValidation(matrix,beeRow,beeCol))
                    {
                        if (matrix[beeRow, beeCol] == 'f')
                        {
                            matrix[beeRow, beeCol] = '.';
                            polinatedFlowers++;
                        }
                     else if (matrix[beeRow, beeCol] == 'O')
                        {
                            matrix[beeRow, beeCol] = '.';
                            continue;                          

                        }
                    }
                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                    command = Console.ReadLine();
                }
                if (CellCoordinatesValidation(matrix,beeRow,beeCol)) 
                {                    
                matrix[beeRow, beeCol] = 'B';
                }
                if (polinatedFlowers >= 5)
                {
                    Console.WriteLine($"Great job, the bee managed to pollinate {polinatedFlowers} flowers!");
                }
                else
                {
                    Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - polinatedFlowers} flowers more");
                }

                PrintMatrix(matrix);
            }

        

        static bool CellCoordinatesValidation(char[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }

        static void CreateMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];

                }
            }

        }

        static void PrintMatrix(char[,] matrix)
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
