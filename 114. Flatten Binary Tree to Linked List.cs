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
    public void Flatten(TreeNode root) 
    {
        /*
        Preorder is: visit node, go left, go right
        start at root, move left if possible and "save" right node as Right
        as we go "left" keep adding any "right" nodes as the Right and have their rights to the prev Right
        */
        Helper(root);
    }
    
    public TreeNode Helper(TreeNode node)
    {
        // exit strat
        if(node == null)
            return null;
        
        var toReturn = node;
        
        // flatten the current node
        var leftSide = Helper(node.left);
        var rightSide = Helper(node.right);
        
        // set the right to be the leftSide
        node.right = leftSide;
        
        // iterate to the end
        while(node.right != null)
        {
            node = node.right;
        }
        
        // set the rightSide to continue at the end
        node.right = rightSide;
        
        // null out the left side
        toReturn.left = null;
        
        return toReturn;
    }
}