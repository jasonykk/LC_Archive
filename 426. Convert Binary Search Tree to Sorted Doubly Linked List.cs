/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;

    public Node() {}

    public Node(int _val) {
        val = _val;
        left = null;
        right = null;
    }

    public Node(int _val,Node _left,Node _right) {
        val = _val;
        left = _left;
        right = _right;
    }
}
*/


public class Solution 
{
    Node smallest;
    Node largest;
    
    public Node TreeToDoublyList(Node root) 
    {
        if(root == null)
            return null;
        
        Helper(root);
        smallest.left = largest;
        largest.right = smallest;
        
        return smallest;
    }
    
    public void Helper(Node node)
    {
        if(node == null)
            return;
        
        // call left child
        Helper(node.left);
        
        if(largest == null)
        {
            // set the first node because we have now found the smallest node (leftmost)
            smallest = node;
        }
        else
        {
            largest.right = node;
            node.left = largest;
        }
        
        // set the largest node to the current node as we're done with all left children
        largest = node;
        
        // call right child
        Helper(node.right);
    }
}


/*
public class Solution 
{
    public Node TreeToDoublyList(Node root) 
    {
        var result = Helper(root);
        //set the first/last relationship
        if(result != null)
        {
            //find largest        
            Node largestNode = result;
            while(largestNode.right != null)
            {
                largestNode = largestNode.right;
            }      
            
            //find smallest
            Node smallestNode = result;
            while(smallestNode.left != null)
            {
                smallestNode = smallestNode.left;
            }
            
            // set the relationship
            smallestNode.left = largestNode;
            largestNode.right = smallestNode;
            
            return smallestNode;
        }
        
        return result;
    }
    
    public Node Helper(Node node)
    {
        if(node == null)
            return node;
        
        // check the children
        var leftCall = Helper(node.left);
        if(leftCall == null)
        {
            node.left = null;
        }
        else
        {
            // since it's the "smaller" child, we want the right most value to be set
            while(leftCall.right != null)
            {
                leftCall = leftCall.right;
            }
            node.left = leftCall;
            leftCall.right = node;
        }
        
        var rightCall = Helper(node.right);
        if(rightCall == null)
        {
            node.right = null;
        }
        else
        {
            // since it's the "larger" child, we want the left most value to be set
            while(rightCall.left != null)
            {
                rightCall = rightCall.left;
            }
            node.right = rightCall;
            rightCall.left = node;
        }
        
        return node;
    }
}

*/