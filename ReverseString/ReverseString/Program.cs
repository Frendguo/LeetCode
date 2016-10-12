using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 问题描述：

    Write a function that takes a string as input and returns the string reversed.

    Example:
    Given s = "hello", return "olleh".
 */


namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine().ToString();
            string s = ReverseString(str);
            Console.WriteLine(s);
            Console.ReadLine();
        }

        public static string ReverseString(string s)
        {
            if (s == null || s.Length < 0)
            {
                return s;
            }

            char[] ch = s.ToArray();
            int firstHalt = 0;

            for (int i = ch.Length - 1; i >= ch.Length / 2; i--)
            {
                char tmp = ch[i];
                ch[i] = ch[firstHalt];
                ch[firstHalt++] = tmp;
            }

            return new string(ch);
        }
    }
}
