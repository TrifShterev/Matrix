using System;
using System.Linq;

namespace Maximal_Sum_3x3Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];
            var matrix = CreateMatrix(rows, cols);

            int maxSum = int.MinValue;
            int startCoordinateOfInnerMatrixRow = 0;
            int startCoordinateOfInnerMatrixCol = 0;

            for (int row  = 0; row < matrix.GetLength(0)-2; row++)
            {
                
                for (int col = 0; col < matrix.GetLength(1)-2; col++)
                {
                    int sum = 0;

                    sum += matrix[row, col] + matrix[row + 1, col] + matrix[row + 2, col];
                    sum += matrix[row, col+1] + matrix[row , col+2] + matrix[row + 1, col+2];
                    sum += matrix[row+2, col+1] + matrix[row+2 , col+2] + matrix[row + 1, col+1];
                    
                    
                    if (maxSum < sum)
                    {
                        maxSum=sum;

                        startCoordinateOfInnerMatrixRow = row;
                        startCoordinateOfInnerMatrixCol = col;
                    }
                }
               
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int i = startCoordinateOfInnerMatrixRow; i < startCoordinateOfInnerMatrixRow+3; i++)
            {
                for (int j = startCoordinateOfInnerMatrixCol; j < startCoordinateOfInnerMatrixCol+3; j++)
                {
                    Console.Write(matrix[i,j] +" ");
                }
                Console.WriteLine();
            }

        }
        
        private static int[,] CreateMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                
                int[] currentRow = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
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
