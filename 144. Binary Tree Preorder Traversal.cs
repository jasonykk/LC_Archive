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
    public IList<int> PreorderTraversal(TreeNode root) 
    {
        if(root == null)
            return new List<int>();
        
        var toReturn = new List<int>();
        var nodeStack = new Stack<TreeNode>();
        // add in the root
        nodeStack.Push(root);
        
        while(nodeStack.Count() > 0)
        {
            var currentNode = nodeStack.Pop();
            toReturn.Add(currentNode.val);
            if(currentNode.right != null)
                nodeStack.Push(currentNode.right);
            if(currentNode.left != null)
                nodeStack.Push(currentNode.left);
        }
        
        return toReturn;
        
    }
    
    
    public IList<int> PreorderTraversalRecursion(TreeNode root) 
    {
        var toReturn = new List<int>();
        
        if(root != null)
        {
            toReturn.Add(root.val);
            toReturn.AddRange(PreorderTraversal(root.left));
            toReturn.AddRange(PreorderTraversal(root.right));
        }
        
        return toReturn;
        
    }
    
}