using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 问题描述：

    Given an array of integers, every element appears twice except for one.
    Find that single one.

*/

namespace SingleNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3, 2, 1 };
            Console.WriteLine("the single number is {0}!",SingleNumber(nums));
            Console.Read();
        }

        public static int SingleNumber(int[] nums)
        {
            List<int> list = nums.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                int tmp = list[0];
                list.RemoveAt(0);
                if (!list.Contains(tmp))
                {
                    return tmp;
                }
            }
            return 0;
        }
    }
}
