﻿using System;
using System.Linq;

namespace Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = ParseArrayFromConsole();
            int rows = input[0];
            int cols = input[1];
            string snakeName = Console.ReadLine();

            char[,] matrix = new char[rows, cols];
            int currentLetter = 0;
            for (int row = 0; row < rows; row++)
            {
               
                    if (row % 2==0)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                        matrix[row, col] = snakeName[currentLetter];
                        currentLetter++;
                        if (currentLetter == snakeName.Length)
                        {
                            currentLetter = 0;
                        }
                    }
                        
                }
                else
                {
                    for (int col = cols-1 ; col >=0; col--)
                    {
                        matrix[row, col] = snakeName[currentLetter];
                        currentLetter++;
                        if (currentLetter == snakeName.Length)
                        {
                            currentLetter = 0;
                        }
                    }
                }
                   
                
            }
            PrintMatrix(matrix);
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
        static int[] ParseArrayFromConsole(params int[] symbolsToSplitBy)
        {
            return Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }
        
    }
   
}
