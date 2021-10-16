/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution 
{
    public List<int> toReturn = new List<int>();    
    
    // in order traversal: left, root, right
    
    public IList<int> InorderTraversal(TreeNode root) 
    {        
        if(root == null)
            return toReturn;
        
        var nodeStack = new Stack<TreeNode>();
        var currentNode = root;
        
        while(nodeStack.Count() > 0 || currentNode != null)
        {
            while(currentNode != null)
            {
                // keep going left!
                nodeStack.Push(currentNode);
                currentNode = currentNode.left;
            }
            
            // we've gone as much left as possible, add the current value and see if we can go right
            var lastNode = nodeStack.Pop();
            toReturn.Add(lastNode.val);
            // add back the previous node val and go right
            currentNode = lastNode.right;
        }
        
        return toReturn;
        
    }
    
    public IList<int> InorderTraversalRecursion(TreeNode root) 
    {        
        if(root != null)
        {
            if(root.left != null)
                InorderTraversalRecursion(root.left);

            toReturn.Add(root.val);

            if(root.right != null)
                InorderTraversalRecursion(root.right);
        }
        return toReturn;
        
    }
    
    
    
}