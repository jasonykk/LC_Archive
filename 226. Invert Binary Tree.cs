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
    public TreeNode InvertTree(TreeNode root) 
    {
        SwapChildren(root);
        return root;        
    }
    
    public void SwapChildren(TreeNode node)
    {
        if(node == null)
            return;
        
        var leftChild = node.left;
        var rightChild = node.right;
        
        node.left = rightChild;
        node.right = leftChild;
        
        SwapChildren(node.left);
        SwapChildren(node.right);
    }
}