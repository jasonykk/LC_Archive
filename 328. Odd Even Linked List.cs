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
    public ListNode OddEvenList(ListNode head) 
    {
        if(head == null || head.next == null)
            return head;
        
        ListNode oddNode = head;
        ListNode evenNodeStart = head.next;
        ListNode evenNodeCurrent = head.next;
        
        while(true)
        {
            // check the next even node
            oddNode.next = evenNodeCurrent.next;
            if(oddNode.next == null)
                break;
            
            // set the next odd node
            oddNode = oddNode.next;
            
            // we are now at the next odd node
            evenNodeCurrent.next = oddNode.next;            
            evenNodeCurrent = evenNodeCurrent.next;
            if(evenNodeCurrent == null)
                break;
                         
        }
        
        // repoint last oddNode to the first even Node
        oddNode.next = evenNodeStart;
        // empty out the last "next" on even
        if(evenNodeCurrent != null)
            evenNodeCurrent.next = null;
        
        
        // the first node never changes
        return head;
        
    }
}