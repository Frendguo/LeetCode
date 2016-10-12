using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 问题描述：

    You are playing the following Nim Game with your friend: 
    There is a heap of stones on the table, each time one of you take turns to remove 1 to 3 stones.
    The one who removes the last stone will be the winner. You will take the first turn to remove the stones.

    Both of you are very clever and have optimal strategies for the game.
    Write a function to determine whether you can win the game given the number of stones in the heap.

    For example, 
    if there are 4 stones in the heap, 
    then you will never win the game: 
    no matter 1, 2, or 3 stones you remove, the last stone will always be removed by your friend.
     */

namespace NimGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入所剩石子的数量：");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0)
            {
                Console.WriteLine("您输入的有误！");
                return;
            }
            if (canWinNim(n))
            {
                Console.WriteLine("您能获得胜利！");
            }
            else
            {
                Console.WriteLine("对不起，您不能获得胜利！");
            }

            Console.ReadLine();
        }

        public static bool canWinNim(int n)
        {
            return n % 4 != 0;
        }
    }
}
