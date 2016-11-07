using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 问题描述：
 * A binary watch has 4 LEDs on the top which represent the hours (0-11), 
 * and the 6 LEDs on the bottom represent the minutes (0-59).

   Each LED represents a zero or one, with the least significant bit on the right.
   
   Example:

    Input: n = 1
    Return: ["1:00", "2:00", "4:00", "8:00", "0:01", "0:02", "0:04", "0:08", "0:16", "0:32"]
    
   Note:
    The order of output does not matter.
    
    The hour must not contain a leading zero, for example "01:00" is not valid, it should be "1:00".
    
    The minute must be consist of two digits and may contain a leading zero, 
    for example "10:2" is not valid, it should be "10:02".
*/
namespace BinaryWatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入亮着的LED的盏数：");
            int n = int.Parse(Console.ReadLine());
            string st = "";
            IList<string> str = ReadBinaryWatch(n);
            foreach (string item in str)
            {
                st = st + " " + item;
            }
            Console.WriteLine("可能的时间为：{0}", st);
            Console.ReadLine();
        }

        static IList<string> ReadBinaryWatch(int num)
        {
            IList<string> list = new List<string>();
            list.Clear();
            for (int h = 0; h < 12; h++)
            {
                for (int m = 0; m < 60; m++)
                {
                    if ((GetOneBit(h, 4) + GetOneBit(m, 6)) == num)
                    {
                        list.Add(string.Format("{0}:{1:00}", h, m));
                    }
                }
            }
            return list;
        }

        static int GetOneBit(int num, int bit)
        {
            int res = 0;
            while(num != 0)
            {
                res += (num & 1);
                num >>= 1;
            }
            return res;
        }
    }
}
