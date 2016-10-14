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
            Console.WriteLine("15 + 16 = {0}", GetSum_Point(15, 16));
            Console.Read();
        }

        public static int GetSum(int a, int b)
        {
            while (b != 0)
            {
                int sum = a ^ b;
                int carry = (a & b) << 1;

                a = sum;
                b = carry;
            }
            return a;
        }

        //利用指针的偏移来实现两数之和
        unsafe public static int GetSum_Point(int a, int b)
        {
            unsafe
            {
                byte* c = (byte*)a;
                int d = (int)&c[b];
                return d;
            }
        }
    }
}
