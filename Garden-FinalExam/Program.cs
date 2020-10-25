using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Garden_FinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).ToArray();
            var rowLength = dimensions[0];
            var colLength = dimensions[1];

            var matrix = new int[rowLength][];

            for (int row = 0; row < rowLength; row++)
            {
                matrix[row] = new int[colLength];
                for (int col = 0; col < colLength; col++)
                {
                    matrix[row][col] = 0;
                }
            }

            var plantedCoordinates = new List<Flower>();
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "Bloom Bloom Plow")
                {
                    BlowAll(matrix, plantedCoordinates);
                    break;
                }

                var rowAndCow = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).ToArray();
                var row = rowAndCow[0];
                var col = rowAndCow[1];

                if (row >= rowLength || col >= colLength)
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    plantedCoordinates.Add(new Flower(row, col));

                    matrix[row][col] = 1;
                }
            }

            Print(matrix);
            Console.ReadLine();
        }

        public static void Print(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }

                Console.WriteLine();
            }
        }

        public static void BlowAll(int[][] matrix, List<Flower> flowers)
        {
            foreach (var flower in flowers)
            {
                BlowSigle(matrix, flower.Row, flower.Col);
            }
        }

        public static void BlowSigle(int[][] matrix, int flowerRow, int flowerCol)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                if (row != flowerRow)
                {
                    matrix[row][flowerCol]++;
                }
            }

            for (int col = 0; col < matrix[flowerRow].Length; col++)
            {
                if (col != flowerCol)
                {
                    matrix[flowerRow][col]++;
                }
            }
        }
    }

    public class Flower
    {
        public Flower(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }

        public int Col { get; private set; }
    }
}
