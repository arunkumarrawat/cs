using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 463. Island Perimeter - https://leetcode.com/problems/island-perimeter/ - AC
    public class IslandPerimeter_463
    {
        public int IslandPerimeter(int[,] grid)
        {
            int result = 0;

            //@example: C# - loop 2d array - 
            int x = grid.GetUpperBound(0) + 3;
            int y = grid.GetUpperBound(1) + 3;
            
            int[,] newGrid = new int[x,y];

            // @idea: add one extra columns and rows, compare around all neight, if neight is 0 then the side is count, there is neight, the side will be not count.
            for (int i = 0; i <= grid.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= grid.GetUpperBound(1); j++)
                {
                    newGrid[i + 1, j + 1] = grid[i, j];
                }
            }

            for (int i = 1; i <= grid.GetUpperBound(0)+1; i++)
            {
                for (int j = 1; j <= grid.GetUpperBound(1)+1; j++)
                {
                    if (newGrid[i, j] == 1)
                    {
                        if (newGrid[i - 1, j] == 0) result += 1;
                        if (newGrid[i + 1, j] == 0) result += 1;
                        if (newGrid[i, j - 1] == 0) result += 1;
                        if (newGrid[i, j + 1] == 0) result += 1;
                    }
                }
            }

            return result;
        }

        public static void main()
        {
            int[,] grid = new int[,] { { 0, 1, 0, 0 }, { 1, 1, 1, 0 }, { 0, 1, 0, 0 }, { 1, 1, 0, 0 } };

            IslandPerimeter_463 s = new IslandPerimeter_463();
            s.IslandPerimeter(grid);

        }
    }
}
