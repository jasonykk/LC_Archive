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
    public int index = 0;
    
    public TreeNode BstFromPreorder(int[] preorder) 
    {
        if(preorder.Count() == 0)
            return null;
        
        return BstFromPreorder(preorder, Int32.MaxValue);
        
    }
    
    
    public TreeNode BstFromPreorder(int[] preorder, int maxValue) 
    {
        if(index >= preorder.Length || preorder[index] > maxValue)
            return null;
            
        var currentNode = new TreeNode(preorder[index]);
        index += 1;
        // keep going left as long as its smaller
        currentNode.left = BstFromPreorder(preorder, currentNode.val);
        // we set the right only if its not larger than the maxValue (can't go right if its larger than the previous node)
        currentNode.right = BstFromPreorder(preorder, maxValue);
        
        return currentNode;
        
    }
    
}