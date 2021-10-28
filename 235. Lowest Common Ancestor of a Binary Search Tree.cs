/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution 
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) 
    {
        if(root == null)
            return null;
        
        if((root.val >= p.val && root.val <= q.val)
          || (root.val <= p.val && root.val >= q.val))
            return root;
        
        var leftCheck = LowestCommonAncestor(root.left, p, q);
        
        if(leftCheck == null)
        {
            return LowestCommonAncestor(root.right, p, q);
        }
        else
        {
            return leftCheck;
        }
        
    }
}