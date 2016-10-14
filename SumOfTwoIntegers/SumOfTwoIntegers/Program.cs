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
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("{0} + {1} = {2}", a, b, GetSum(a, b));
            //Console.WriteLine("{0} + {1} = {2}", a, b, GetSum_Point(a, b));
            Console.WriteLine("{0} - {1} = {2}", a, b, GetMargin(a, b));
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

        public static int GetMargin(int a, int b)
        {
            while (b != 0)
            {
                // 去掉被减数和减数中同为1的位
                int sameNum = a & b;
                a ^= sameNum;
                b ^= sameNum;
                
                // 此时，a 和 b 不存在同时为1 的位
                // 0 - 1 和 1 - 0 都为1
                a |= b; // 得到相减的临时结果（不考虑借位）
                b = b << 1; // 减数为1 时，必有借位
            }
            return a;
        }
    }
}
