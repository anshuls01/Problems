using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.PillsvsGerms
{
    public class PillsvsGermsDFS
    {
        public static int m, n , maxGermsCount = 0;
        public static void CountRemainingGerms()
        {
             
            int[] input = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            m = input[0];
            n = input[1];

            bool[,] visited = new bool[m, n];
            char[,] arr = new char[m, n];
            int[] rRow = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] rColumn = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };
            int[] bRow = new int[] { -1, 0, 0, 1 };
            int[] bColumn = new int[] { 0, 1, -1, 0 };

            //Assume no pills in a given input
            maxGermsCount = m * n;

            //Read the matrix from console

            for (int i = 0; i < m; i++)
            {
                char[] temp = Console.ReadLine().ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = temp[j];
                }
            }


            //Read each input
            for (int i = 0; i < m; ++i)
                for (int j = 0; j < n; ++j)
                    if ((arr[i, j] == 'r' || arr[i, j] == 'b') && !visited[i, j])
                    {
                        visited[i, j] = true;
                        maxGermsCount--;
                        if (arr[i, j] == 'r')
                        {
                            DFS(arr, i, j, visited, 8,rRow,rColumn);
                           
                        }
                        else if (arr[i, j] == 'b')
                        {
                            DFS(arr, i, j, visited, 4,bRow,bColumn);
                        }
                    }

            Console.WriteLine(maxGermsCount);

        }

        //Reference GeekForGeeks https://www.geeksforgeeks.org/find-number-of-islands/
        static void DFS(char[,] arr, int row, int col, bool[,] visited, int value,int[] cRow, int[] cColumn)
        {

            for (int k = 0; k < value; k++)
            {

                if (isSafe(arr, row + cRow[k], col + cColumn[k], visited))
                {
                    maxGermsCount--;
                    visited[row + cRow[k], col + cColumn[k]] = true;
                }
                
            }
                                                        
        }

        static bool isSafe(char[,] M, int row, int col, bool[,] visited)
        {

            return (row >= 0) && (row < m) && (col >= 0) && (col < n) && (M[row, col] == 'x' && !visited[row, col]);
        }

    }
}
