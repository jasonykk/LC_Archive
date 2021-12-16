/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node parent;
}
*/

public class Solution 
{
    public Node LowestCommonAncestor(Node p, Node q) 
    {
        /*
        given our starting points are the actual 2 nodes, we don't know where they are relative to all other nodes. We need a way to keep track of which nodes have been visited. 
            - use a HashSet for this
            
        Given that its a normal binary tree and not a binary search tree, the node value tells us nothing about other nodes.
        
        So we keep searching the parents of the nodes we find. the moment a value has been seen, that is our LCA
        
        O(h) to find the LCA assuming both nodes are on opposite ends so we must search to the root
        */
        
        HashSet<int> foundVals = new HashSet<int>();
        // add our starting 2 nodes
        foundVals.Add(p.val);
        foundVals.Add(q.val);
        
        while(p.parent != null || q.parent != null)
        {
            if(p.parent != null)
            {
                p = p.parent;
                if(!foundVals.Add(p.val))
                    return p;
            }
            
            if(q.parent != null)
            {
                q = q.parent;
                if(!foundVals.Add(q.val))
                    return q;
            }
        }
        
        // if we get here, that means that this is an invalid tree (given no LCA)
        return null;
        
    }
}