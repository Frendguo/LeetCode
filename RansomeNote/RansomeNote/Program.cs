using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 问题描述：
 * Given an arbitrary ransom note string and another string containing letters 
 * from all the magazines, write a function that 
 * will return true if the ransom note can be constructed from the magazines ;
 * otherwise, it will return false.

    Each letter in the magazine string can only be used once in your ransom note.

    Note:
    You may assume that both strings contain only lowercase letters.

    canConstruct("a", "b") -> false
    canConstruct("aa", "ab") -> false
    canConstruct("aa", "aab") -> true
*/

namespace RansomeNote
{
    class Program
    {
        static void Main(string[] args)
        {
            string ransomeNote = "aa";
            string magazine = "aab";

            Solution sol = new Solution();
            if (sol.CanConstruct(ransomeNote, magazine))
            {
                Console.WriteLine("YES!!!");
            }
            else
            {
                Console.WriteLine("NOT!!!");
            }

            Console.Read();
        }
    }

    public class Solution
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            /*利用数组实现*/
            int[] table = new int[26];
            foreach (char ch in magazine)
            {
                table[ch - 'a']++;
            }
            foreach (char ch in ransomNote)
            {
                if (--table[ch - 'a'] < 0)
                {
                    return false;
                }
            }

            return true;

            ///*利用链表的Add 和 Remove 实现*/
            //List<char> list = new List<char>();
            //foreach (char c in magazine)
            //{
            //    list.Add(c);
            //}
            //foreach (char ch in ransomNote)
            //{
            //    if (!list.Remove(ch))
            //    {
            //        return false;
            //    }
            //}

            //return true;
        }
    }
}
