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
    public bool IsSymmetric(TreeNode root) 
    {
        // if we traverse the left of root and build a string of vals as we proceed, we can do the same for the right and compare them
        
        StringBuilder leftS = new StringBuilder();
        StringBuilder rightS = new StringBuilder();
        IsSymmetricTree(root.left, leftS, true);
        IsSymmetricTree(root.right, rightS, false);
        
        //Console.WriteLine($"left:{leftS.ToString()}");
        //Console.WriteLine($"right:{rightS.ToString()}");
        
        return leftS.ToString() == rightS.ToString();
    }
    
    public void IsSymmetricTree(TreeNode root, StringBuilder sb, bool isLeft)
    {
        if(root != null)
        {
            if(isLeft)
            {
                sb.Append(root.val);
                IsSymmetricTree(root.left, sb, true);
                IsSymmetricTree(root.right, sb, true);
            }
            else
            {
                sb.Append(root.val);
                IsSymmetricTree(root.right, sb, false);
                IsSymmetricTree(root.left, sb, false);
            }
        }
        else
            sb.Append("null");
    }
    
}