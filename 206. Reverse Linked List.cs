/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution 
{    
    public ListNode ReverseList(ListNode head) 
    {
        // recurse till the end, set current to point to previous and return previous
        //return ReverseList(head, null);        
        
        // iteratively swap the nodes
        return ReverseListIterative(head);
    }
    
    public ListNode ReverseListIterative(ListNode head)
    {
        ListNode previous = null;
        while(head != null)
        {
            // get next
            var next = head.next;
            // save current head to previous node
            head.next = previous;
            // save new previous node
            previous = head;
            // set head to be the next node
            head = next;
        }
        return previous;
    }
    
    
    public ListNode ReverseListRecurse(ListNode head, ListNode node)
    {
        if(head == null)
            return node;
        // save reference to the next node (will be lost otherwise)
        var newNext = head.next;
        // set current head.next to the previous node
        head.next = node;
        // set head to be next (by recursion)
        return ReverseListRecurse(newNext, head);
        
    }
    
}