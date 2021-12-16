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
    public int GetDecimalValue(ListNode head) 
    {
        return BruteForce(head);
    }
    
    public int BruteForce(ListNode head)
    {
        /*
        Create a list (cant be an array since we don't know how long it goes) of characters
        For each node, add the associated value to the list
        At the end when there are no longer any nodes, cast the list of characters to a string
        From a string we can cast it to an int from binary        
        */
        
        List<char> stagingResults = new List<char>();
        
        while(head != null)
        {
            if(head.val == 1)
                stagingResults.Add('1');
            else
                stagingResults.Add('0');
            
            head = head.next;
        }
        
        string binaryString = new string(stagingResults.ToArray());
        return Convert.ToInt32(binaryString, 2);
        
        
    }
}