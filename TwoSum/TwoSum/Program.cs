using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

/*
 问题描述：
 Given an array of integers, return indices of the two numbers such
 that they add up to a specific target.

You may assume that each input would have exactly one solution.

Example:
Given nums = [2, 7, 11, 15], target = 9,

Because nums[0] + nums[1] = 2 + 7 = 9,
return [0, 1].
     
 */

namespace CsharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 2, 4 };
            int target = 6;
            int[] result = new int[2];
            if ((result = TwoSum(nums, target)) != null)
            {
                Console.WriteLine("the nums is : {0} {1}", result[0], result[1]);
            }
            else
            {
                Console.WriteLine("您的目标数无法达到！");
            }

            Console.Read();
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            /*使用字典的键值对*/
            // TKey : 数组的值
            // TValue : 数组序号
            Dictionary<int, int> valueIndex = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int res = target - nums[i];

                if (valueIndex.ContainsKey(res))
                {
                    return new int[] { valueIndex[res], i };
                }
                else
                {
                    if (!valueIndex.ContainsKey(nums[i]))
                    {
                        valueIndex.Add(nums[i], i);
                    }
                }
            }

            return null;

            /*常规方法*/
            //int[] result = new int[2];
            //for (int i = 0; i < nums.Length;  i++)
            //{
            //    for (int j = i + 1; j < nums.Length; j++)
            //    {
            //        if (nums[i] + nums[j] == target)
            //        {
            //            result[0] = i;
            //            result[1] = j;
            //            return result;
            //        }
            //    }
            //}
            //return null;
        }
    }
}
