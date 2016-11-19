using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 问题描述：
 * You are climbing a stair case. It takes n steps to reach to the top.
 * Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
 */

namespace ClimbingStairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("结果是 {0}.", ClimbStairs(n));
            Console.ReadLine();
        }

        // 动态规划
        // https://zh.wikipedia.org/wiki/%E5%8A%A8%E6%80%81%E8%A7%84%E5%88%92
        static int ClimbStairs(int n)
        {
            if (n <= 2) return n;
            int[] table = new int[n + 1];
            table[1] = 1;
            table[2] = 2;

            //return recursion(n, table);
            return iteration(n, table);
        }

        static int recursion(int n, int[] table)
        {
            if (table[n] != 0) return table[n];
            int sum = 0;
            sum = recursion(n - 1, table);
            sum += recursion(n - 2, table);
            table[n] = sum;
            return sum; 
        }

        static int iteration(int n, int[] table)
        {
            for (int i = 3; i <= n; i++)
            {
                table[i] = table[i - 1] + table[i - 2];
            }

            return table[n];
        }
    }
}
