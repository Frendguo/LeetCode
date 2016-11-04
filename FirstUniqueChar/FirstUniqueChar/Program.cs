using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 问题描述：
 * Given a string, find the first non-repeating character in it and 
 * return it's index. If it doesn't exist, return -1.

    Examples:

    s = "leetcode"
    return 0.

    s = "loveleetcode",
    return 2.

    Note: 
    You may assume the string contain only lowercase letters.
 
 */

namespace FirstUniqueChar
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "leetleetcode";
            Console.WriteLine("this first unique character index is {0}.", FirstUniqueChar(s));
            Console.Read();
        }

        static int FirstUniqueChar(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return -1;
            }
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            foreach (var ch in s)
            {
                if (!dictionary.ContainsKey(ch))
                {
                    dictionary.Add(ch, 1);
                }
                else
                {
                    dictionary[ch]++;
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (dictionary[s[i]] == 1)
                {
                    return i;
                }
            }

            return -1;
        }
    }

}
