using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.PillsvsGerms
{
    public static class PillsvsGerms
    {
        public static void CountRemainingGerms()
        {
            int m, n = 0;
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
            int maxGermsCount = m * n;

            //Read the matrix from console

            for (int i = 0; i < m; i++)
            {
                char[] temp = Console.ReadLine().ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = temp[j];
                }
            }

            //printArray(arr);

            //Read each input
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((arr[i, j] == 'r' || arr[i, j] == 'b') && !visited[i, j])
                    {
                        //new pill found
                        visited[i, j] = true;
                        maxGermsCount--;
                        //remove the germs around
                        if (arr[i, j] == 'r')
                        {
                            for (int k = 0; k < 8; k++)
                            { int row = i + rRow[k];
                                int col = j + rColumn[k];
                                if (row >= 0 && row < m && col >= 0 && col < n && (arr[row,col] == 'x' && !visited[row,col]))
                                {
                                    maxGermsCount--;
                                    visited[row, col] = true;
                                }
                            }
                        }
                        else if (arr[i, j] == 'b')
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                int row = i + bRow[k];
                                int col = j + bColumn[k];
                                if (row >= 0 && row < m && col >= 0 && col < n && (arr[row, col] == 'x' && !visited[row, col]))
                                {
                                    maxGermsCount--;
                                    visited[row, col] = true;
                                }
                            }
                        }

                    }
                }
            }

            Console.WriteLine(maxGermsCount);

        }



        private static void printArray(string[][] array)
        {
            int m = array.Length;
            //print Matrix (Jagged Array)
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine(string.Join(' ', array[i]));
            }

        }
    }
}
