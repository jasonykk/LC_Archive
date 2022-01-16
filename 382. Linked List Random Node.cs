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
    List<int> lookup;
    Random random;

    public Solution(ListNode head) 
    {
        lookup = new List<int>();
        random = new Random();
        
        while(head != null)
        {
            lookup.Add(head.val);
            head = head.next;
        }
    }
    
    public int GetRandom() 
    {
        var randomIndex = random.Next(lookup.Count);
        return lookup[randomIndex];
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(head);
 * int param_1 = obj.GetRandom();
 */