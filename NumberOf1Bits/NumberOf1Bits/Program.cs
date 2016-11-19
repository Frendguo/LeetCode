using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/** 
 * 问题描述：
 * 
 * Write a function that takes an unsigned integer and returns the number of ’1' bits it has 
 * (also known as the Hamming weight).
 * 
 * For example, the 32-bit integer ’11' has binary representation 
 * 00000000000000000000000000001011, so the function should return 3.
 * */

namespace NumberOf1Bits
{
    class Program
    {
        static void Main(string[] args)
        {
            uint n = 11;
            Console.WriteLine("the number is {0}", NumberOfBits(n));
            Console.Read();
        }

        static int NumberOfBits(uint n)
        {
            /*方法一：位运算直接计算*/
            //int sum = 0;
            //while (n != 0)
            //{
            //    sum += (int)(n & 1);
            //    n >>= 1;
            //}
            //return sum;

            /*方法二：*/
            return Convert.ToString(n, 2).Replace("0", "").Length;
        }
    }
}
