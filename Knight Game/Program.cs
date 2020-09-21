using System;
using System.Linq;

namespace Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var matrix=CreateMatrix(n, n);

            int counter = 0;

            while (true)
            {

                int maxAttackedKnights = 0;
                int maxAttackedKnightsRow = -1;
                int maxAttackedKnightsCol = -1;
                
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        var ch = matrix[row, col];
                        if (ch=='K')
                        {
                           int currentAttackedKnights= GetCountAttackedKnights(matrix,row,col);
                            if (currentAttackedKnights>maxAttackedKnights)
                            {
                                maxAttackedKnights = currentAttackedKnights;
                                maxAttackedKnightsRow = row;
                                maxAttackedKnightsCol = col;
                            }
                        }
                    }
                }
                if (maxAttackedKnights==0)
                {
                    break;
                }
                matrix[maxAttackedKnightsRow, maxAttackedKnightsCol] = '0';
                counter++;
            }
            Console.WriteLine(counter);
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
            if (row-2>=0&&col-1>=0&&matrix[row-2,col-1]=='K')
            {
                counter++;
            }
            if (row - 2 >= 0 && col + 1 <n && matrix[row - 2, col + 1] == 'K')
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
            if (row +1 < n && col - 2 >= 0 && matrix[row + 1, col - 2] == 'K')
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
        private static char[,] CreateMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
               
                char[] currentRow = Console.ReadLine()            
                .ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }
    }
}
