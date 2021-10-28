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
    public bool IsValidBST(TreeNode root) 
    {
        return IsValidBST(root, Int64.MaxValue, Int64.MinValue);
    }
    
    public bool IsValidBST(TreeNode node, long maxVal, long minVal) 
    {
        if(node == null)
            return true;
        
        if(node.val >= maxVal || node.val <= minVal)
            return false;
        
        return IsValidBST(node.left, node.val, minVal) && IsValidBST(node.right, maxVal, node.val);
    }
    
}