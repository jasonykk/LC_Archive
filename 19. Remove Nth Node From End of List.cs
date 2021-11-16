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
    public ListNode RemoveNthFromEnd(ListNode head, int n) 
    {
        // we need a "moving" window from the latest as this helps us remove it
        // keeping an extra in the window allows us to immediately bypass the node
        // given the n can be equal to the # of nodes, if it exceeds then there is nothing to remove
        
        ListNode node = head;
        ListNode pivot = null;
        int count = 0;
        
        
        // iterate till the end
        while(node != null)
        {
            // we've reached the window and can start setting the node to skip
            if(count >= n)
            {
                if(pivot == null)
                {
                    pivot = head;
                }
                else
                {
                    // move the pivot out
                    pivot = pivot.next;
                }
            }
            
            node = node.next;
            count += 1;
        }
        
        //Console.WriteLine($"pivot:{pivot.val}");
        
        // we have reached the end, remove the nth node now (if its equal to the size of sz there is nothing to remove)
        if(pivot != null && pivot.next != null)
        {
            pivot.next = pivot.next.next;
        }
        
        // if we didnt find any node to pivot on, the head is removed instead
        if(pivot == null)
            return head.next;
        
        return head;
    }
}