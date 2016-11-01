using System;

/**
 * 问题描述：
 * Given an array nums, 
 * write a function to move all 0's to the end of it 
 * while maintaining the relative order of the non-zero elements.

    For example, given nums = [0, 1, 0, 3, 12], 
        after calling your function,
        nums should be [1, 3, 12, 0, 0].
*/

namespace MoveZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 0, 1, 0, 3, 12 };
            Solution sol = new Solution();
            sol.MoveZeroes(nums);
            foreach (int n in nums)
            {
                Console.WriteLine(n);
            }
            Console.Read();
        }
    }

    public class Solution
    {
        public void MoveZeroes(int[] nums)
        {
            int n = 0; // 统计0的个数
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    n++;
                }
                else if (n != 0)
                {
                    nums[i - n] = nums[i];
                    nums[i] = 0;
                }
            }
        }
    }
}
