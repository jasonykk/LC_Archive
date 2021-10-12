/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution 
{
    public bool HasCycle(ListNode head) 
    {
        // slow and fast walker for constant memory solution
        
        // optimization
        if(head == null || head.next == null)
            return false;
        
        var walker = head;
        var runner = head;
        
        // we exit the moment either does not have a "next". that means there is no cycle
        while(walker.next != null && runner.next != null && runner.next.next != null)
        {
            walker = walker.next;
            runner = runner.next.next;
            
            // if they meet, we've found a cycle
            if(walker == runner)
            {
               return true; 
            }
        }
        
        return false;
        
    }
    
    
    public bool HasCycleV1(ListNode head) 
    {
        // ASSUMPTION: Adding to hashset is unique given the next node and val
        // we can use a hashset to see if we've seen a value before
        
        // optimization
        if(head == null)
            return false;
        
        var lookup = new HashSet<ListNode>();
        
        while(head.next != null)
        {
            if(lookup.Add(head))
            {
               head = head.next; 
            }
            else
                return true;
            
        }
        
        return false;
        
    }
}