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
    int sum;
    
    public int SumOfLeftLeaves(TreeNode root) 
    {
        // search down in a recursive fashion until we find leaf nodes
        // must pass in whether we're traversing left so we know its a leaf node
        sum = 0;
        SumOfLeafLeaves(root, false);
        return sum;
        
    }
    
    public void SumOfLeafLeaves(TreeNode node, bool isLeft)
    {
        if(node == null)
            return;
        
        if(node.left == null && node.right == null && isLeft)
        {
            sum += node.val;
            return;
        }
        
        if(node.left != null)
        {
            SumOfLeafLeaves(node.left, true);
        }
        
        if(node.right != null)
        {
            SumOfLeafLeaves(node.right, false);
        }
        
        
    }
}