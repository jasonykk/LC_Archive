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
    public TreeNode InsertIntoBST(TreeNode root, int val) 
    {
        // bst our way to a null and insert?
        if(root == null)
            return new TreeNode(val);
        
        InsertIntoBSTRecursion(root, val);
        return root;
    }
    
    
    public void InsertIntoBSTRecursion(TreeNode root, int val) 
    {
        // bst our way to a null and insert?
        
        if(root.val < val)
        {
            if(root.right == null)
            {
                root.right = new TreeNode(val);
                return;
            }
            else
                InsertIntoBSTRecursion(root.right, val);
        }
        else
        {
            if(root.left == null)
            {
                root.left = new TreeNode(val);
                return;
            }
            else
                InsertIntoBSTRecursion(root.left, val);
        }
        
        
    }
    
}