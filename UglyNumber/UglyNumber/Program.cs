using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 问题描述：
 * 
 * Write a program to check whether a given number is an ugly number.
 * 
 * Ugly numbers are positive numbers whose prime factors(质因子) only include 2, 3, 5. 
 * For example, 6, 8 are ugly while 14 is not ugly since it includes another prime factor 7.
 * 
 * Note that 1 is typically treated as an ugly number.
 * */

namespace UglyNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            if (IsUglyNumber(n))
                Console.WriteLine("The number is UglyNumber!");
            else
                Console.WriteLine("The number isn't UglyNumber!");

            Console.Read();
        }

        static bool IsUglyNumber(int num)
        {
            ///*方法一：递归*/
            //if (num <= 1 || num == 7) return false;
            //if (num < 10) return true;
            //if (num % 2 == 0)
            //    return IsUglyNumber(num / 2);
            //if (num % 3 == 0)
            //    return IsUglyNumber(num / 3);
            //if (num % 5 == 0)
            //    return IsUglyNumber(num / 5);
            //return false;

            /*方法二： 循环*/
            if (num < 1 || num == 7) return false;
            if (num < 10) return true;

            while (num % 2 == 0) num /= 2;
            while (num % 3 == 0) num /= 3;
            while (num % 5 == 0) num /= 5;

            return num == 1;
        }
    }
}
