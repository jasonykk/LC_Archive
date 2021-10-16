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
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) 
    {
        // recurse to the end of both lists
        // compare the values and set the appropriate next value
        // return the smaller value
        // on return comparisons, the larger node's next pointer must be to the returned smaller value
        
        if(l1 == null)
            return l2;
        if(l2 == null)
            return l1;
        if(l1.val <= l2.val)
        {
            l1.next = MergeTwoLists(l1.next, l2);
            return l1;
        }
        else
        {
            l2.next = MergeTwoLists(l2.next, l1);
            return l2;
        }
           
        
    }
}