using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind75
{
    public class RemoveNthNodeFromEndOfList
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            //Remove (L-n+1)th node from the beginning of the list
            //Edge Cases:
            //1. Remove head from the list
            //2. Only one node in the list

            //Approach: Single pass fast slow pointer approach:
            //Pointer 1: Advance to n+1 steps from the beginning
            //Pointer 2: Starts at the beginning of the list
            //Pointer 1 will be faster than Pointer 2 and both will have n node distance between the,

            //Define Dummy node to point to head
            ListNode dummy = new ListNode(0);
            dummy.next = head;

            //Point both the pointers to dummy pointer
            ListNode fast = dummy;
            ListNode slow = dummy;

            //Advance fast pointer to move past n and gap between fast and slow pointer should be maintained as n nodes apart
            for (int i = 1; i <= n + 1; i++)
            {
                fast = fast.next;
            }

            //Upon moving fast pointer past n, move fast pointer to the end and slow pointer towards fast pointer maintaining gap of n nodes
            while (fast != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            //At this point, fast pointer is moved past end of the LinkedList and slow pointer on nth node which we need to remove
            //Set slow.next = slow.next.next to remove nth node
            slow.next = slow.next.next;
            return dummy.next;
        }
    }

    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

}
