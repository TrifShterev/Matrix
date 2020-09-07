using System;
using System.Linq;

namespace Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = CreateMatrix(n, n);
            PrimeDiagonalSum(matrix);
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

        private static int[,] CreateMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                //TO FILL THE SYMBOLS I SPLIT BY here:
                int[] currentRow = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }

    }
}
