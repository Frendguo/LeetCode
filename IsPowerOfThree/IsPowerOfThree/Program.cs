using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 问题描述：
 * Given an integer, write a function to determine（确定） if it is a power of three.

    Follow up:
    Could you do it without using any loop / recursion?
**/

namespace IsPowerOfThree
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            if (IsPowerOfThree(n))
            {
                Console.WriteLine("{0} is power of three!", n);
            }
            else
            {
                Console.WriteLine("{0} isn't power of three!", n);
            }

            Console.Read();
        }

        /// <summary>
        /// 判断是否为三的幂
        /// </summary>
        /// <param name="n"></param>
        /// 发现 三的幂数 的因子一定也是三的幂数
        /// <returns></returns>
        static bool IsPowerOfThree(int n)
        {
            int powerMax = (int)Math.Pow(3, (int)Math.Log(int.MaxValue, 3));
            return (n > 0 && powerMax % n == 0);
        }
    }
}
