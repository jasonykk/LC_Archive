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
    public ListNode MergeKLists(ListNode[] lists) 
    {
        if(lists == null || lists.Length == 0)
            return null;
        
        Queue<ListNode> todo = new Queue<ListNode>();
        
        // add the first node of each list
        foreach(var node in lists)
        {
            //Console.WriteLine($"node:{node.val}");
            todo.Enqueue(node);
        }
        
        // keep merging until we're done
        while(todo.Count > 1)
        {
            ListNode n1 = todo.Dequeue();
            ListNode n2 = todo.Count > 0 ? todo.Dequeue() : null;
            
            var merged = MergeLists(n1, n2);
            
            todo.Enqueue(merged);
            
        }
        
        return todo.Dequeue();
        
    }
    
    public ListNode MergeLists(ListNode n1, ListNode n2)
    {
        if(n2 == null)
            return n1;
        if(n1 == null)
            return n2;
        if(n1.val < n2.val)
        {
            n1.next = MergeLists(n1.next, n2);
            return n1;
        }
        else
        {
            n2.next = MergeLists(n2.next, n1);
            return n2;
        }
    }
}