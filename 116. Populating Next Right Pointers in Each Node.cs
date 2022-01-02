/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution 
{
    public Node Connect(Node root) 
    {
        LinkedList<Node> nextLevel = new LinkedList<Node>();
        nextLevel.AddFirst(root);
        SetNextLevel(nextLevel);
        return root;
    }
    
    public void SetNextLevel(LinkedList<Node> nextLevel)
    {
        var processLength = nextLevel.Count;
        Node prev = null;
        
        // set next
        foreach(var node in nextLevel)
        {
            if(prev == null)
            {
                prev = node;
            }
            else
            {
                prev.next = node;
                prev = node;
            }
        }
        
        // remove and add the child nodes as we go
        int count = 0;
        while(count < processLength)
        {
            var current = nextLevel.First();
            // remove the current node
            nextLevel.RemoveFirst();
            
            // increment the counter of removed nodes            
            count += 1;
            
            // since its a perfect tree, we can just check if the left child exists
            if(current != null && current.left != null)
            {
                nextLevel.AddLast(current.left);
                nextLevel.AddLast(current.right);
            }
        }
        
        if(nextLevel.Count > 0)
        {
            SetNextLevel(nextLevel);
        }
            
    }
}