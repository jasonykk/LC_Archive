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
    public ListNode DetectCycle(ListNode head) 
    {
        // assuming O(n) memory use, we can keep unique nodes in a hashset and return the node that fails to be added (since it exists)
        HashSet<ListNode> dupeFound = new HashSet<ListNode>();
        while(head != null)
        {
            if(!dupeFound.Add(head))
            {
                return head;
            }
            head = head.next;
        }
        return null;
        
    }
}