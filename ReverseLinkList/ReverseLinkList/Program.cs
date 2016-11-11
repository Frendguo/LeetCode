using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 问题描述：
 * Reverse a singly linked list.
 * */

namespace ReverseLinkList
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static ListNode ReverseLink(ListNode head)
        {
            /*方法一： 迭代法*/
            if (head == null || head.next == null) return head;
            ListNode p = head.next;
            head.next = null;
            ListNode q = p;
            while (q != null)
            {
                q = q.next;
                p.next = head;
                head = p;
                p = q;
            }
            return head;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
