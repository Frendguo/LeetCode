using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 问题描述：
 * Given n points in the plane that are all pairwise distinct, 
 * a "boomerang" is a tuple of points (i, j, k) such that the distance 
 * between i and j equals the distance between i and k (the order of the tuple matters).

    Find the number of boomerangs. You may assume that n will be at most 500 
    and coordinates of points are all in the range [-10000, 10000] (inclusive).

    Example:
    Input:
    [[0,0],[1,0],[2,0]]

    Output:
    2

    Explanation:
    The two boomerangs are [[1,0],[0,0],[2,0]] and [[1,0],[2,0],[0,0]]
*
*/

namespace NumberOfBoomerang
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] points = new int[,] { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
            Console.WriteLine("{0}", NumberOfBoomerang(points));
            Console.Read(); 
        }

        static int NumberOfBoomerang(int[,] points)
        {
            int length = points.GetLength(0);
            if (length < 3) return 0;
            int val = 0;
            int res = 0;
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i != j)
                    {
                        val = (points[i, 0] - points[j, 0]) * (points[i, 0] - points[j, 0])
                                + (points[i, 1] - points[j, 1]) * (points[i, 1] - points[j, 1]);
                        if (!dictionary.ContainsKey(val))
                        {
                            dictionary[val] = 1;
                        }
                        else
                        {
                            dictionary[val]++;
                        }
                    }
                }
                foreach (var t in dictionary.Values)
                {
                    res += t * (t - 1);
                }
                dictionary.Clear();
            }

            
            return res;
        }

    }
}
