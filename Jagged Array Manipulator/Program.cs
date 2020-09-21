using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] matrix = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] rowValues = Console.ReadLine().Split().Select(double.Parse).ToArray();
                matrix[row] = rowValues;
            }
            for (int row = 0; row < rows - 1; row++)
            {
                double[] rowOne = matrix[row];
                double[] rowTwo = matrix[row + 1];

                if (rowOne.Length == rowTwo.Length)
                {
                    matrix[row] = rowOne.Select(x => x * 2).ToArray();
                    matrix[row + 1] = rowTwo.Select(x => x * 2).ToArray();
                }
                else
                {
                    matrix[row] = rowOne.Select(x => x / 2).ToArray();
                    matrix[row + 1] = rowTwo.Select(x => x / 2).ToArray();
                }

            }
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                string command = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (!IsValidCellInJaggedArray(matrix, row, col))
                {
                    continue;
                }

                if (command == "Add")
                {
                    matrix[row][col] += value;
                }
                else if (command == "Subtract")
                {
                    matrix[row][col] -= value;
                }
            }
            PrintJaggedMatrix(rows, matrix);
        }

        private static void PrintJaggedMatrix(int rows, double[][] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }

        private static bool IsValidCellInJaggedArray(double[][] matrix, int row, int col)
        {
            bool isValid = false;
            if (row>=0 &&row<matrix.Length&& col>=0 && col<matrix[row].Length)
            {
                isValid = true;
            }
            return isValid;
        }
    }
}
