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
    public bool FindTarget(TreeNode root, int k) 
    {
        HashSet<int> lookup = new HashSet<int>();
        return FindTarget(root, k, lookup);
        
    }
    
    public bool FindTarget(TreeNode node, int k, HashSet<int> lookup) 
    {
        if(node == null)
            return false;
        
        var currentLookup = (k - node.val);
        if(lookup.Contains(currentLookup))
            return true;
        
        lookup.Add(node.val);        
        // recurse down the tree
        if(FindTarget(node.left, k, lookup))
            return true;

        if(FindTarget(node.right, k, lookup))
           return true;

        return false;
        
    }
    
    
}