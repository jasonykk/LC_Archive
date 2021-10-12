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
    // we need to find the max diameter (length) at EACH node since the path may not pass the root
    // by recursively calling each node all the way to the leaf, we can return value + 1 at each stage to account for the edge backtracked
    // adding the values from children nodes (left + right) gives us the max diameter at a particular node
    // keep comparing the max diameter with saved value to see if we found a better solution
    
    
    public int toReturn;
    
    public int DiameterOfBinaryTree(TreeNode root) 
    {
        toReturn = 0;
        CalculateMaxDiameterFromNode(root);
        return toReturn;
        
    }
    
    public int CalculateMaxDiameterFromNode(TreeNode node)
    {
        if(node == null)
            return 0;
        
        int leftHeight = CalculateMaxDiameterFromNode(node.left);
        int rightHeight = CalculateMaxDiameterFromNode(node.right);
        
        // go down the left and right children to find the diameters at each side
        // update the toReturn value if the max height is more
        toReturn = Math.Max(toReturn, leftHeight + rightHeight);
        
        // return the longest length (NOT diameter) at this node but add 1 since we're going back up 1 level (thats the edge between current and previous node)
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}