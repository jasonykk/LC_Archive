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
    // hash table to keep and check for dupes
    public HashSet<int> lookup;

    public ListNode DeleteDuplicates(ListNode head) 
    {
        lookup = new HashSet<int>();
        //DeleteDuplicatesRecursive(head, null);
        DeleteDuplicatesIterative(head);
        return head;
    }
    
    public void DeleteDuplicatesIterative(ListNode head)
    {
        ListNode previous = null;
        while(head != null)
        {
            if(lookup.Add(head.val))
            {
                // we did not find any dupes
                // update previous and go next
                previous = head;
                head = head.next;            
            }
            else
            {
                // found a dupe, we point previous to next
                // recurse back at the next node
                previous.next = head.next;
                head = head.next;
            }
        }
    }
    
    public void DeleteDuplicatesRecursive(ListNode head, ListNode previous) 
    {
        if(head != null)
        {
            if(lookup.Add(head.val))
            {
                // we did not find any dupes
                // update previous and go next
                DeleteDuplicatesRecursive(head.next, head);                
            }
            else
            {
                // found a dupe, we point previous to next
                // recurse back at the next node
                previous.next = head.next;
                DeleteDuplicatesRecursive(head.next, previous);   
            }
        }
        
    }
    
    
}