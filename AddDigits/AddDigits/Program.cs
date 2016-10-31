using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 问题描述：
 * Given a non-negative integer num, repeatedly add all its digits until the result has only one digit.

    For example:

    Given num = 38, the process is like: 3 + 8 = 11, 1 + 1 = 2. 
    Since 2 has only one digit, return it.

    Follow up:
    Could you do it without any loop/recursion in O(1) runtime?
 * 
*/
namespace AddDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            Console.WriteLine("the solution is {0}", sol.AddDigits(38));
            Console.Read();
        }
    }

    public class Solution
    {
        public int AddDigits(int num)
        {
            if (num == 0) return 0;
            return (num - 1) % 9 + 1;
        }
    }
}
