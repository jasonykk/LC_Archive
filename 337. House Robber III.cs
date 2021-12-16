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
    public int Rob(TreeNode root) 
    {
        // root cannot be null per contraints
        if(root.right == null && root.left == null)
            return root.val;
                
        int[] results = RobHelper(root);
        return Math.Max(results[0], results[1]);
    }
    
    /*
    Return a two value array. [0] will contain values if the node is taken, [1] is the node will not
    */
    public int[] RobHelper(TreeNode node) 
    {
        if(node == null)
        {
            // if node is empty, there is nothing to do
            return new int[] { 0, 0};
        }
        else
        {
            int[] leftSubTree = RobHelper(node.left);
            int[] rightSubTree = RobHelper(node.right);
            
            int robCurrentNode = node.val + leftSubTree[1] + rightSubTree[1];
            // we consider the max between both the child node and without the child node. Reason: we can skip 2 nodes to if left child node + grandchild of right node gives maximum value
            int skipCurrentNode = Math.Max(leftSubTree[0], leftSubTree[1]) + Math.Max(rightSubTree[0], rightSubTree[1]);
            
            return new int[] { robCurrentNode, skipCurrentNode };            
        }
    }
    
}