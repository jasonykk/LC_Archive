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
    public ListNode SwapPairs(ListNode head) 
    {
        if(head == null)
            return null;
        
        if(head.next == null)
            return head;
        
        // set the return point
        ListNode toReturn = head.next;
        
        // do the first swap
        ListNode n1 = SwapNodes(null, head, head.next);
        ListNode prev = head;
        
        // swap until we reach the end!
        while(n1 != null)
        {
            ListNode nextPrev = n1;
            n1 = SwapNodes(prev, n1, n1.next);
            prev = nextPrev;
        }
            
        return toReturn;
    }
    
    public ListNode SwapNodes(ListNode prev, ListNode n1, ListNode n2)
    {        
        if(n1 == null || n2 == null)
            return null;
        
        n1.next = n2.next;        
        n2.next = n1;
        
        if(prev != null)
            prev.next = n2;
        
        return n1.next;
    }
}