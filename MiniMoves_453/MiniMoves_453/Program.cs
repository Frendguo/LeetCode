using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Given a non-empty integer array of size n, 
 * find the minimum number of moves required to make all array elements equal, 
 * where a move is incrementing n - 1 elements by 1.
 * Example:

    Input:
    [1,2,3]

    Output:
    3

    Explanation:
    Only three moves are needed (remember each move increments two elements):

    [1,2,3]  =>  [2,3,3]  =>  [3,4,3]  =>  [4,4,4]
*/

namespace MiniMoves_453
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 5, 2, 3, 2, 6 };
            Console.WriteLine("要使数组元素都相等，至少需要移动{0}步！", MiniMoves(nums));
            Console.Read();
        }

        static int MiniMoves(int[] nums)
        {
            /*方法一*/
            // 将每次 n - 1个元素相加转化成
            // 每次将一个元素相减
            if (nums.Length <= 1)
            {
                return 0;
            }
            Array.Sort(nums);
            int sum = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                sum += nums[i] - nums[0];
            }
            return sum;
        }
    }
}
