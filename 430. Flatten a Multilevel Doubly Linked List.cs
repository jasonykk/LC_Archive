/*
// Definition for a Node.
public class Node {
    public int val;
    public Node prev;
    public Node next;
    public Node child;
}
*/

public class Solution 
{
    public Node Flatten(Node head) 
    {
        Stack<Node> nextStack = new Stack<Node>();        
        Flatten(head, nextStack);        
        return head;        
    }
    
    public void Flatten(Node node, Stack<Node> nextStack)
    {
        if(node == null)
            return;
                
        if(node.child != null)
        {
            // found a child, add next to the stack and point next to the child
            if(node.next != null)
                nextStack.Push(node.next);
            
            node.next = node.child;
            node.child.prev = node;
            node = node.child;
            node.prev.child = null;
        }
        else if(node.next != null)
        {
            // go to the next node if there is no child
            node = node.next;
        }
        else if(nextStack.Count > 0)
        {
            // if there is no child or no next node, we pop from the stack
            var currentNode = nextStack.Pop();
            node.next = currentNode;
            currentNode.prev = node;
            node = node.next;
        }
        else
        {
            // if there is no child, no next node and nothing in the stack, we're done
            return;
        }
        
        Flatten(node, nextStack);
    }
    
}