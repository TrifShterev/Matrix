using System;
using System.IO;
using System.Linq;

namespace Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPresents = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());

            char[,] neighburhood = new char[size, size];
            var santasRow = -1;
            var santasCol = -1;

            for (int row = 0; row < neighburhood.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < neighburhood.GetLength(1); col++)
                {
                    neighburhood[row, col] = currentRow[col];
                    if (neighburhood[row, col] == 'S')
                    {
                        santasRow = row;
                        santasCol = col;
                        neighburhood[row, col] = '-';
                    }
                }
            }

            int goodKidsCount = 0;
            string input;
               while ((input = Console.ReadLine()) != "Christmas morning")
                {
                    switch (input)
                    {
                        case "up":
                            santasRow--;
                            break;
                        case "down":
                            santasRow++;
                            break;
                        case "left":
                            santasCol--;
                            break;
                        case "right":
                            santasCol++;
                            break;
                    }
                    if (neighburhood[santasRow,santasCol]=='X')
                    {
                    neighburhood[santasRow, santasCol] = '-';
                    continue;
                    }
                    else if (neighburhood[santasRow, santasCol] == 'V')
                    {
                    goodKidsCount++;
                        numOfPresents--;
                        neighburhood[santasRow, santasCol] = '-';
                        continue;
                    }
                    else if (neighburhood[santasRow, santasCol] == 'C')
                    {
                    var stepUp = neighburhood[santasRow-1, santasCol];
                    var stepDown = neighburhood[santasRow+1, santasCol];
                    var stepLeft = neighburhood[santasRow, santasCol-1];
                    var stepRight = neighburhood[santasRow, santasCol+1];
                        if (stepUp== 'X'||stepUp == 'V')
                    {
                        if (stepUp == 'V')
                        {
                            goodKidsCount++;
                        }
                            numOfPresents--;
                        neighburhood[santasRow-1, santasCol]='-';
                        if (numOfPresents<=0)
                            break;
                        

                        }
                        if (stepDown == 'X' ||stepDown == 'V')
                        {
                        if (stepDown == 'V')
                        {
                            goodKidsCount++;
                        }
                        numOfPresents--;
                        neighburhood[santasRow+1, santasCol] = '-';
                        if (numOfPresents <= 0)
                            break;

                    }
                        if (stepLeft == 'X' || stepLeft == 'V')
                        {
                        if (stepLeft == 'V')
                        {
                            goodKidsCount++;
                        }
                        numOfPresents--;
                        neighburhood[santasRow, santasCol-1] = '-';
                        if (numOfPresents <= 0) break;
                    }
                        if (stepRight == 'X' || stepRight == 'V')
                        {
                        if (stepRight == 'V')
                        {
                            goodKidsCount++;
                        }
                        numOfPresents--;
                        neighburhood[santasRow, santasCol+1] = '-';
                        if (numOfPresents <= 0) 
                            break;
                    }
                    }
                if (numOfPresents <= 0)
                    break;
            }
            if (numOfPresents==0)
            {
                Console.WriteLine("Santa ran out of presents!");
            }

            neighburhood[santasRow, santasCol] = 'S';
            PrintMatrix(neighburhood);

            var kidsWithoutPresents = 0;
            foreach (var item in neighburhood)
            {
                if (item=='V')
                {
                    kidsWithoutPresents++;
                }
            }
            if (kidsWithoutPresents==0)
            {
                Console.WriteLine($"Good job, Santa! {goodKidsCount} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {kidsWithoutPresents} nice kid/s.");
            }
        }
        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]+" ");
                }

                Console.WriteLine();
            }
        }
    }
}
