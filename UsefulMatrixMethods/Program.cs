using System;
using System.Linq;

namespace UsefulMatrixMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        private static void SwapsTwoElementsInMatrix(string[,] matrix, int rowOne, int colOne, int rowTwo, int colTwo)
        {
            var temp = matrix[rowOne, colOne];
            matrix[rowOne, colOne] = matrix[rowTwo, colTwo];
            matrix[rowTwo, colTwo] = temp;
        }
        private static bool CellCoordinatesValidation(string[,] matrix, int rowOne, int colOne)
        {
            return rowOne >= 0 && rowOne < matrix.GetLength(0) && colOne >= 0 && colOne < matrix.GetLength(1);
        }
        private static int SecondDiagonalSum(int[,] matrix)
        {
            var curCol = 0;
            var diagonalSum = 0;
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                if (curCol > matrix.GetLength(1))
                {
                    curCol = 0;
                    break;
                }
                else
                {
                    diagonalSum += matrix[row, curCol];
                    curCol++;
                }
            }
            return diagonalSum;
        }
        private static void PrimeDiagonalSum(int[,] matrix)
        {
            var curCol = 0;
            var diagonalSum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (curCol > matrix.GetLength(1))
                {
                    curCol = 0;
                    break;
                }
                else
                {
                    diagonalSum += matrix[row, curCol];
                    curCol++;
                }
            }
            Console.WriteLine(diagonalSum);
        }
        private static void SumOfMatrixColumns(int[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int colSum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    colSum += matrix[row, col];
                }
                Console.WriteLine(colSum);
            }
        }
        private static int[,] CreateMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                //TO FILL THE SYMBOLS I SPLIT BY here:
                int[] currentRow = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

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
        private static bool CheckIndexes(int[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
        private static void PrintMatrix(int[,] matrix)
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
    }
}
