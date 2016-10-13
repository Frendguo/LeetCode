using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
问题描述：

Calculate the sum of two integers a and b, but you are not allowed to use the operator + and -.

Example:
Given a = 1 and b = 2, return 3. 
 
*/

namespace SumOfTwoIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("15 + 16 = {0}", GetSum(15, 16));
            Console.Read();
        }

        public static int GetSum(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }

            int sum = a ^ b;
            int carry = (a & b) << 1;

            int result = GetSum(sum, carry);

            return result;
        }
    }
}
