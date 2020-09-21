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
        static int GetCountAttackedKnights(char[,] matrix, int row, int col)
        {
            //0K0K0- this method checks by the horse/knight moves at the chess board 
            //K000K Knight-'K'  also checks how many Knights are at the board
            //00K00
            //K000K
            //0K0K0
            int counter = 0;
            int n = matrix.GetLength(0);
            //UP Above the middle 'K' on the board
            if (row - 2 >= 0 && col - 1 >= 0 && matrix[row - 2, col - 1] == 'K')
            {
                counter++;
            }
            if (row - 2 >= 0 && col + 1 < n && matrix[row - 2, col + 1] == 'K')
            {
                counter++;
            }
            if (row - 1 >= 0 && col - 2 >= 0 && matrix[row - 1, col - 2] == 'K')
            {
                counter++;
            }
            if (row - 1 >= 0 && col + 2 < n && matrix[row - 1, col + 2] == 'K')
            {
                counter++;
            }
            //Down from the middle 'K'
            if (row + 1 < n && col - 2 >= 0 && matrix[row + 1, col - 2] == 'K')
            {
                counter++;
            }
            if (row + 1 < n && col + 2 < n && matrix[row + 1, col + 2] == 'K')
            {
                counter++;
            }
            if (row + 2 < n && col - 1 >= 0 && matrix[row + 2, col - 1] == 'K')
            {
                counter++;
            }
            if (row + 2 < n && col + 1 < n && matrix[row + 2, col + 1] == 'K')
            {
                counter++;
            }
            return counter;
        }
        private static bool ValidateCellInJaggedMatrix(double[][] matrix, int row, int col)
        {
            bool isValid = false;
            if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
            {
                isValid = true;
            }
            return isValid;
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
        private static void PrintJaggedMatrix(int rows, double[][] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
    }
}
