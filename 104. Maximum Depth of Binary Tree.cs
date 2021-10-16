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
    public int max;
    
    public int MaxDepth(TreeNode root) 
    {
        // traverse the tree until we find a leaf, add in current depth and compare with max
        max = 0;
        MaxDepth(root, 1);
        return max;
    }
    
    public void MaxDepth(TreeNode root, int currentDepth)
    {
        if(root == null)
            return;
        
        if(root.left == null && root.right == null)
        {
            // it's a leaf, see if we have a deeper depth
            max = Math.Max(max, currentDepth);
        }
        else
        {
            MaxDepth(root.left, currentDepth+1);
            MaxDepth(root.right, currentDepth+1);
        }
    }
    
}