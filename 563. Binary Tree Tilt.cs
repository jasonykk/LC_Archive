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
    int toReturn = 0;
    
    public int FindTilt(TreeNode root) 
    {
        /*
        We need the sum of leftSubtree and sum of rightSubtree
        Each would make a call to FindTilt until there are no children
        The absolute is added to the returned value and the actual sum returns up the stack
        
        */
        Helper(root);
        return toReturn;
    }
    
    // returns the current sum of the children and current value
    public int Helper(TreeNode node)
    {
        if(node == null)
            return 0;
        
        int leftSum = Helper(node.left);
        int rightSum = Helper(node.right);
        
        toReturn += Math.Abs(leftSum - rightSum);
        
        return leftSum + rightSum + node.val;        
    }
    
    
    public int GetNodeValue(TreeNode node)
    {
        if(node == null)
            return 0;
        else
            return node.val;
    }
    
}