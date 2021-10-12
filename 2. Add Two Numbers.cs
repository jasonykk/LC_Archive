/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        int carryValue = 0;
        ListNode toReturn = null;
        ListNode previousNode = null;
        ListNode newNode = null;
        
        while(true)
        {
            // get current value
            int currentValue = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + carryValue;
            
            // save added value
            newNode = new ListNode(currentValue % 10);                
            
            // set node linking as needed
            if(previousNode != null)
                previousNode.next = newNode;
            else
                toReturn = newNode;
            
            // reset previousNode to current node!
            previousNode = newNode;
            
            // update addOne if needed            
            carryValue = (currentValue / 10);
            
            l1 = SetNode(l1);
            l2 = SetNode(l2);
            
            if(l1 == null && l2 == null)
                break;
        }
        
        // last check to add finalNode
        if(carryValue != 0)
            previousNode.next = new ListNode(1);
        
        return toReturn;
    }
    
    public ListNode SetNode(ListNode node)
    {
        if(node != null && node.next != null)
        {
            node = node.next;
            return node;
        }
        return null;
    }
}