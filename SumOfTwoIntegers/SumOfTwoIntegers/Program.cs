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
            Console.WriteLine("{0} x {1} = {2}", a, b, GetProduct(a, b));
            Console.WriteLine("{0} / {1} = {2}", a, b, GetQuotient(a, b));
            //Console.WriteLine("{0}", Convert.ToString(maxNumFlag(), 16)); //以十六进制显示数据
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

        // 辅助函数
        public static int maxNumFlag()
        {
            int bitsOfByte = 8;

            int maxNum = 0x80;
            int tmp = maxNum;
            while (tmp != 0)
            {
                maxNum = tmp;
                tmp <<= bitsOfByte;
            }
            return maxNum;
        }

        public static int GetProduct(int a, int b)
        {
            // 1.先只考虑正整数的相乘
            // 2.考虑正负情况和溢出问题

            int maxNum = maxNumFlag();
            int flag_a = 1;
            if ((maxNum & a) != 0)
            {
                flag_a = 0; // 负数
                a = GetSum(~a, 1);
            }

            int flag_b = 1;
            if ((maxNum & b) != 0)
            {
                flag_b = 0;
                b = GetSum(~b, 1);
            }

            int result = 0;
            for (int bits = 1; bits != 0; bits <<= 1)
            {
                if ((bits & b) != 0)
                {
                    result = GetSum(result, a);
                    if ((result & maxNum) != 0
                        || (a & maxNum) != 0)
                    {
                        throw new Exception("数据过大！");
                    }
                }
                a <<= 1;
            }

            return (flag_a ^ flag_b) == 0 ? result : GetSum(~result, 1);
        }

        public static int GetQuotient(int a, int b)
        {
            ///*方法一*/
            //if (b == 0)
            //{
            //    throw new Exception("除数不能为0！！");
            //}

            //int maxNum = maxNumFlag();
            //int flag_a = 1;
            //if ((maxNum & a) != 0)
            //{
            //    flag_a = 0; // 负数
            //    a = GetSum(~a, 1);
            //}

            //int flag_b = 1;
            //if ((maxNum & b) != 0)
            //{
            //    flag_b = 0;
            //    b = GetSum(~b, 1);
            //}

            //int index = 1;
            //int tmp = GetMargin(a, b);
            //if (tmp < 0)
            //{
            //    return 0;
            //}

            //while (tmp >= b)
            //{
            //    tmp = GetMargin(tmp, b); // 最后一次循环后的tmp 便是a/b 的余数
            //    index = GetSum(index, 1);
            //}
            //return (flag_a ^ flag_b) == 0 ? index : GetSum(~index, 1);

            /*方法二*/
            if (b == 0)
            {
                throw new Exception("除数不能为0！！");
            }

            int maxNum = maxNumFlag();
            int flag_a = 1;
            if ((maxNum & a) != 0)
            {
                flag_a = 0; // 负数
                a = GetSum(~a, 1);
            }

            int flag_b = 1;
            if ((maxNum & b) != 0)
            {
                flag_b = 0;
                b = GetSum(~b, 1);
            }

            int quotient = 0;
            int backupB = b;
            while (a >= b)
            {
                int tempB = b << 1;
                int tempQ = 1;
                while ((tempB <= a) && ((tempB & maxNumFlag()) == 0))
                {
                    b = tempB;
                    tempQ <<= 1;
                    tempB <<= 1;
                }

                a = GetMargin(a, b);
                quotient |= tempQ;
                b = backupB;
            }
            return (flag_a ^ flag_b) == 0 ? quotient : GetSum(~quotient, 1);
        }

    }
}
