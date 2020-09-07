using System;
using System.Linq;
namespace Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int[,] matrix = CreateMatrix(n, n);

            string input;
            while ((input=Console.ReadLine())!="END")
            {
                var commandRow = input.Split();
                var command = commandRow[0];
                var indexOfRow = int.Parse(commandRow[1]);
                var indexOfCol = int.Parse(commandRow[2]);
                var value = int.Parse(commandRow[3]);

                switch (command)
                {
                    case "Add":
                        if (CheckIndexes(matrix,indexOfRow,indexOfCol))
                        {
                            matrix[indexOfRow, indexOfCol] += value;
                        }
                        else
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                        break;
                    case "Subtract":
                        if (CheckIndexes(matrix, indexOfRow, indexOfCol))
                        {
                            matrix[indexOfRow, indexOfCol] -= value;
                        }
                        else
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                        break;
                }

            }PrintMatrix(matrix);
        }
        private static bool CheckIndexes(int [,] matrix,int row, int col)
        {
            if (row>=0&&row<matrix.GetLength(0)&& col>=0&&col<matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
        private static int[,] CreateMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                
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
