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
    List<int> leafVals;
    
    public int SumNumbers(TreeNode root) 
    {
        // have a list that contains all leaf values
        // at each node we must pass in the current val * 10
        // given 4 -> 9 -> 5, we can get 495 by passing 40, adding 9 to 49, then passing 490, before adding 5.
        leafVals = new List<int>();
        
        SumNumbers(root, 0);
        
        return leafVals.Sum();
        
    }
    
    public void SumNumbers(TreeNode node, int val)
    {
        if(node == null)
            return;
        
        if(node.left == null && node.right == null)
        {
            // we've found our leaf node, we can now add to the list
            var currentSum = val + node.val;
            leafVals.Add(currentSum);
        }
        else
        {
            var currentSum = val + node.val;
            
            // keep going left if there are child nodes
            if(node.left != null)
            {
                SumNumbers(node.left, currentSum * 10);
            }
            
            if(node.right != null)
            {
                SumNumbers(node.right, currentSum * 10);
            }
        }
            
    }
    
}