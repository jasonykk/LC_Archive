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
    public TreeNode SearchBST(TreeNode root, int val) 
    {
        // we recurse until we find the val (if possible) 
        // when we find it, return it?
        
        if(root == null)
            return null;
        
        if(root.val == val)
            return root;
        
        if(root.val < val)
            return SearchBST(root.right, val);
        else
            return SearchBST(root.left, val);
    }
}