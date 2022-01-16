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
    int totalSum;
    
    public int SumRootToLeaf(TreeNode root) 
    {
        /*
        Similar to normal recursion but use bit manipulation instead of addition
        */
        totalSum = 0;
        Helper(root, 0);
        return totalSum;
    }
    
    public void Helper(TreeNode node, int val)
    {
        if(node == null)
            return;
        
        // shift the current value left by 1 bit (this moves up all previous values as if it was * 10)
        val = (val << 1);
        // we then OR with the node's value. this tacks on the node's value at the end
        val = val | node.val;
        
        if(node.left == null && node.right == null)
        {
            // on finding a leaf node, add to total sum
            totalSum += val;            
        }
        else
        {
            // keep going down children with new value
            Helper(node.left, val);
            Helper(node.right, val);
        }
    }
    
    /*
    
    public int SumRootToLeaf(TreeNode root) 
    {
        //We keep adding the number until we reach a node that does not have any children.
        //    -when found, add that number to the totalSum
        //When recursing back upwards, we must also remove the last number and we can divide by 10 for that
        //When recursing down, * 10 to get the new value
        
        totalSum = 0;
        Helper(root, "");
        return totalSum;
    }
    
    public void Helper(TreeNode node, string val)
    {
        if(node == null)
            return;
        
        // add the current node's value to the existing value
        val += node.val;
        
        if(node.left == null && node.right == null)
        {
            // on finding a leaf node, add to total sum
            totalSum += GetBinaryFromString(val);            
        }
        else
        {
            // keep going down children with new value
            Helper(node.left, val);
            Helper(node.right, val);
        }
    }
    
    public int GetBinaryFromString(string val)
    {
        //Console.WriteLine(val);
        return Convert.ToInt32(val, 2);
    }

    */
}