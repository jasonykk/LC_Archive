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
    int toReturn;
    
    public int RangeSumBST(TreeNode root, int low, int high) 
    {
        /*
        Because its a BST, left child must be smaller and right child must be bigger.
        We can use this to find all nodes inclusive
            int toReturn contains the actual value
        We start at the root and see if its in that range, if so, add it
        Check the child node (left + right) if they are within the range, if so, call the method again        
        */
        
        toReturn = 0;
        Helper(root, low, high);
        return toReturn;
    }
    
    public void Helper(TreeNode node, int low, int high)
    {
        if(node == null)
            return;
        
        if(node.val >= low && node.val <= high)
        {
            toReturn += node.val;
        }     
            
        //process the child nodes
        if(node.val > low)
            Helper(node.left, low, high);
        
        if(node.val < high)
            Helper(node.right, low, high);   
    }
    
    
}