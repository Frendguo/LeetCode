using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 问题描述：
 * Given two non-negative numbers num1 and num2 represented as string, 
 * return the sum of num1 and num2.

    Note:

    The length of both num1 and num2 is < 5100.
    Both num1 and num2 contains only digits 0-9.
    Both num1 and num2 does not contain any leading zero.
    You must not use any built-in BigInteger library or convert the inputs to integer directly.
*/
namespace AddString
{
    class Program
    {
        static void Main(string[] args)
        {
            string num1 = "1";
            string num2 = "9";
            long num_1 = Convert.ToInt64(num1);
            long num_2 = Convert.ToInt64(num2);

            Console.WriteLine("{0} + {1} = {2}", num_1, num_2, num_1 + num_2);
            Console.WriteLine("{0} 和 {1} 相加的结果是：{2}", num1, num2, AddString(num1, num2));
            Console.Read();
        }

        static string AddString(string num1, string num2)
        {
            int length = (num1.Length > num2.Length ? num1.Length : num2.Length);
            char[] table = new char[length + 1];

            int i_1 = num1.Length - 1;
            int i_2 = num2.Length - 1;
            int flag = 0; // 进位
            int tmp = 0;

            for (int i = length ; i >= 0; i--)
            {
                if (i_1 < 0 && i_2 < 0) // 只剩进位
                {
                    if (flag == 1) table[0] = (char)(1 + '0');
                    break;
                }
                else if (i_1 < 0)
                {
                    tmp = num2[i_2--] - '0' + flag; 
                }
                else if (i_2 < 0)
                {
                    tmp = num1[i_1--] - '0' + flag;
                }
                else
                    tmp = ((num1[i_1--] - '0') + (num2[i_2--] - '0')) + flag;

                flag = tmp / 10;
                table[i] = (char) (tmp % 10 + '0');
            }

            return table[0] == '\0' ? new string(table,1,length) : new string(table);
        }
    }
}
