using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionOfTwoArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = new int[] { 1, 1 };
            int[] nums2 = new int[] { 1, 2 };
            Solution sol = new Solution();
            int[] result = sol.IntersectionOfTwoArrays(nums1, nums2);
            foreach (int item in result)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
    }

    public class Solution
    {
        public int[] IntersectionOfTwoArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length <= 0 || nums2.Length <= 0) return new int[0];

            Dictionary<int, bool> dictionary = new Dictionary<int, bool>();

            List<int> list = new List<int>();

            foreach (int item in nums1)
            {
                if (!dictionary.ContainsKey(item))
                {
                    dictionary.Add(item, true);
                }
            }
            foreach (int item in nums2)
            {
                if (dictionary.ContainsKey(item))
                {
                    if (dictionary[item])
                    {
                        list.Add(item);
                        dictionary[item] = false;
                    }
                }
            }
                
            return list.ToArray();
        }
    }
}
