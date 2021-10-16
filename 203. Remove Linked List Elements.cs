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
    public ListNode RemoveElements(ListNode head, int val) 
    {
        // return if head is null
        // otherwise loop until there is no next node
        // check if value = val and if it is, we point the previous node to the next node
        
        if(head == null)
            return null;
        else
        {
            if(head.next != null)
            {
                if(head.val != val)
                    head.next = RemoveElements(head.next, val);
                else
                    return RemoveElements(head.next, val);
            }
            else
            {
                if(head.val != val)
                    return head;
                else
                    return null;
            }
        }
        
        return head;
        
        
    }
}