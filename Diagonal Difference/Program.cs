using System;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
          var matrix=  CreateMatrix(n, n);
            SecondDiagonalSum(matrix);
            PrimeDiagonalSum(matrix);
            
            Console.WriteLine(Math.Abs(PrimeDiagonalSum(matrix) - SecondDiagonalSum(matrix)));

        }
        private static int SecondDiagonalSum(int[,] matrix)
        {
            var curCol = 0;
            var diagonalSum = 0;
            for (int row = matrix.GetLength(0)-1; row >= 0; row--)
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
        private static int PrimeDiagonalSum(int[,] matrix)
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
           return diagonalSum;
        }
        private static int[,] CreateMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {                
                int[] currentRow = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
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
