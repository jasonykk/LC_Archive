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
    public ListNode InsertionSortList(ListNode head) 
    {
        /*
        Loop until there is no next
        As we pop back up the recursion stack, check if we need to swap 
            If we do need to swap, keep checking the "next" value to see if further swaps are needed
        */
        
        if(head == null)
            return head;
        
        //iterate to the last node
        head.next = InsertionSortList(head.next);
        
        return SwapIfLarger(head);
        
    }
    
    public ListNode SwapIfLarger(ListNode node)
    {
        if(node.next == null)
            return node;
        
        if(node.val < node.next.val)
            return node;
        
        // node.next is smaller so we need to return it instead
        var tempNode = node.next;
        // set the next's value to be the next.next value
        node.next = tempNode.next;
        tempNode.next = SwapIfLarger(node);
        
        return tempNode;
        
    }
    
    
}