using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 问题描述：
 * Given a positive integer, 
 * return its corresponding column title as appear in an Excel sheet.

    For example:

        1 -> A
        2 -> B
        3 -> C
        ...
        26 -> Z
        27 -> AA
        28 -> AB 
*/

namespace ExcelSheetColumnTitle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入N的值：");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("{0} 对应的Title 是：{1}", n, ConvertToTitle(n));
            Console.ReadLine();
        }

        static string ConvertToTitle(int n)
        {
            string st = "";
            while (n != 0)
            {
                st = (char)('A' + (n - 1) % 26) + st;
                n = (n - 1) / 26;
            }
            return st;
        }
    }
}
