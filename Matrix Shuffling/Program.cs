using System;
using System.Linq;

namespace Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = ParseArrayFromConsole();
            int rows = dimensions[0];
            int cols = dimensions[1];

            var matrix= CreateMatrix(rows,cols);
            string comandInput;

            while ((comandInput=Console.ReadLine())!="END")
            {
                string[] tokens = comandInput.Split();

                if (tokens[0] != "swap" || tokens.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                int rowOne = int.Parse(tokens[1]);
                int colOne = int.Parse(tokens[2]);
                int rowTwo = int.Parse(tokens[3]);
                int colTwo = int.Parse(tokens[4]);

                bool isValidFirstCoordinates = CellCoordinatesValidation(matrix, rowOne, colOne);
                bool isValidSecondCoordinates = CellCoordinatesValidation(matrix, rowTwo, colTwo);

                if (!isValidFirstCoordinates || !isValidSecondCoordinates)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                SwapsTwoElementsInMatrix(matrix, rowOne, colOne, rowTwo, colTwo);
                PrintMatrix(matrix);
            }
        }
        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
        private static void SwapsTwoElementsInMatrix(string[,] matrix, int rowOne, int colOne, int rowTwo, int colTwo)
        {
            var temp = matrix[rowOne, colOne];
            matrix[rowOne, colOne] = matrix[rowTwo, colTwo];
            matrix[rowTwo, colTwo] = temp;
        }

        private static bool CellCoordinatesValidation(string[,] matrix, int rowOne, int colOne)
        {
    return rowOne >= 0 && rowOne < matrix.GetLength(0) && colOne >= 0 && colOne<matrix.GetLength(1);
        }

        private static string[,] CreateMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                
                string[] currentRow = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }
        static int[] ParseArrayFromConsole(params char[] splitSymbols)
        {
            return Console.ReadLine()
                .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
