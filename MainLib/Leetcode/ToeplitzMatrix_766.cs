using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    class ToeplitzMatrix_766
    {
        public bool IsToeplitzMatrix(int[][] matrix)
        {
            
            for(int i=0;i<matrix[0].Count();i++)
            {
                int row = 1;
                int main = matrix[0][i];
                while (row < matrix.Count() && (i+row) < matrix[0].Count())
                {
                    if(!(matrix[row][i+row] == main))
                    {
                        return false;
                    }
                    row++;
                }
            }

            for (int i = 0; i < matrix.Count(); i++)
            {
                int colums = 1;
                int main = matrix[i][0];
                while (colums < matrix[0].Count() && (i + colums) < matrix.Count())
                {
                    if (!(matrix[i+ colums][colums] == main))
                    {
                        return false;
                    }
                    colums++;
                }
            }
            return true;
        }
        public static void main()
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[] { 36, 59, 71, 15, 26, 82, 87 };
            matrix[1] = new int[] { 56, 36, 59, 71, 15, 26, 82 };
            matrix[2] = new int[] { 15, 0, 36, 59, 71, 15, 26 };
            ToeplitzMatrix_766 s = new ToeplitzMatrix_766();
            bool result = s.IsToeplitzMatrix(matrix);
            Console.WriteLine(result);
        }
    }
}
