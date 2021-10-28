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
    public int savedTargetSum;
    
    public bool HasPathSum(TreeNode root, int targetSum) 
    {
        if(root == null)
            return false;
        
        savedTargetSum = targetSum;
        return HasPathSumRecursion(root, 0);
    }
    
    public bool HasPathSumRecursion(TreeNode node, int currentSum) 
    {
        // when we've reached a leaf, check for sum
        if(node.left == null && node.right == null)
        {
            if(currentSum + node.val == savedTargetSum)
                return true;
            else
                return false;
        }
        
        if(node.left != null && HasPathSumRecursion(node.left, currentSum + node.val))
            return true;        
        
        if(node.right != null && HasPathSumRecursion(node.right, currentSum + node.val))
            return true;
        
        return false;
        
    }
}