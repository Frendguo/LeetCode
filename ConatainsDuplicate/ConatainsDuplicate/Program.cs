using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 问题描述：
 * Given an array of integers, 
 * find if the array contains any duplicates. 
 * Your function should return true if any value appears at least twice in the array, 
 * and it should return false if every element is distinct.
 * */

namespace ConatainsDuplicate
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3, 1 };
            if (ContainsDupliacate(nums))
                Console.WriteLine("该数组有重复的元素！"); 
            else
                Console.WriteLine("该数组没有重复的元素！");

            Console.Read();
        }

        static bool ContainsDupliacate(int[] nums)
        {
            /*方法一：采用Dictionary 实现*/
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            foreach (int n in nums)
            {
                if (!dictionary.ContainsKey(n)) dictionary.Add(n, 1);
                else return true;
            }
            return false;

        }
    }
}
