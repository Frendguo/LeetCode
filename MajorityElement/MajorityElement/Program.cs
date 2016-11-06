using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 问题描述：
 * Given an array of size n, find the majority element.
 * The majority element is the element that appears more than ⌊ n/2 ⌋ times.

    You may assume that the array is non-empty and 
    the majority element always exist in the array.
*/

namespace MajorityElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3, 3, 2, 2, 2 };
            Console.WriteLine("the array's majority element is {0}", MajorityElement(nums));
            Console.Read();
        }

        static int MajorityElement(int[] nums)
        {
            /*方法一：采用Dictionary 实现*/
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            int n = nums.Length / 2;
            foreach (int i in nums)
            {
                if (dictionary.ContainsKey(i))
                {
                    if (++dictionary[i] > n) return i;
                }
                else
                {
                    dictionary.Add(i, 1);
                    if (dictionary[i] > n) return i;
                }
            }
            return -1;
        }
    }
}
