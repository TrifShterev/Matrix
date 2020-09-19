using System;
using System.Linq;

namespace Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] rowValues= Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }
            int counter = 0;
            for (int row = 0; row < rows-1; row++)
            {
                
                for (int col = 0; col < cols-1; col++)
                {
                    char ch = matrix[row, col];

                    if (ch==matrix[row,col+1]&&ch== matrix[row+1,col]&& ch==matrix[row+1,col+1])
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
