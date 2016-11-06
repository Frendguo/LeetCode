using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 问题描述：
 * Write a program that outputs the string representation of numbers from 1 to n.

    But for multiples of three it should output “Fizz” instead of the number and
    for the multiples of five output “Buzz”. 
    For numbers which are multiples of both three and five output “FizzBuzz”.

    Example:

    n = 15,

    Return:
    [
        "1",
        "2",
        "Fizz",
        "4",
        "Buzz",
        "Fizz",
        "7",
        "8",
        "Fizz",
        "Buzz",
        "11",
        "Fizz",
        "13",
        "14",
        "FizzBuzz"
    ]
*/

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please input number is :");
            int n = Convert.ToInt32(Console.ReadLine());
            List<string> list = FizzBuzz(n);
            Console.WriteLine("the string is :");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        static List<string> FizzBuzz(int n)
        {
            /*方法一：采用 % 判断是否整除*/
            List<string> list = new List<string>();
            int t = 1;
            string[] table = new string[] { "Fizz", "Buzz", "FizzBuzz" };
            while (t <= n)
            {
                if (t % 15 == 0)
                {
                    list.Add(table[2]);
                }
                else if (t % 3 == 0)
                {
                    list.Add(table[0]);
                }
                else if (t % 5 == 0)
                {
                    list.Add(table[1]);
                }
                else
                {
                    list.Add(t.ToString());
                }
                t++;
            }
            return list;
        }
    }
}
