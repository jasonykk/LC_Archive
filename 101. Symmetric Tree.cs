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
        if(root == null)
            return true;
        
        StringBuilder leftS = new StringBuilder();
        StringBuilder rightS = new StringBuilder();
        Stack<TreeNode> nodeStack = new Stack<TreeNode>();
        
        // start left
        nodeStack.Push(root.left);
        while(nodeStack.Count() > 0)
        {
            var currentNode = nodeStack.Pop();
            if(currentNode == null)
                leftS.Append("null");
            else
            {
                leftS.Append(currentNode.val);
                nodeStack.Push(currentNode.left);
                nodeStack.Push(currentNode.right);
            }
            
        }
        
        // check right
        nodeStack.Push(root.right);
        while(nodeStack.Count() > 0)
        {
            var currentNode = nodeStack.Pop();
            if(currentNode == null)
                rightS.Append("null");
            else
            {
                rightS.Append(currentNode.val);
                nodeStack.Push(currentNode.right);
                nodeStack.Push(currentNode.left);
            }
            
        }
        
        //Console.WriteLine($"left:{leftS.ToString()}");
        //Console.WriteLine($"right:{rightS.ToString()}");
        
        return leftS.ToString() == rightS.ToString();
    }
    
    public bool IsSymmetricRecurse(TreeNode root) 
    {
        // if we traverse the left of root and build a string of vals as we proceed, we can do the same for the right and compare them
        
        StringBuilder leftS = new StringBuilder();
        StringBuilder rightS = new StringBuilder();
        IsSymmetricTreeRecursion(root.left, leftS, true);
        IsSymmetricTreeRecursion(root.right, rightS, false);
        
        //Console.WriteLine($"left:{leftS.ToString()}");
        //Console.WriteLine($"right:{rightS.ToString()}");
        
        return leftS.ToString() == rightS.ToString();
    }
    
    public void IsSymmetricTreeRecursion(TreeNode root, StringBuilder sb, bool isLeft)
    {
        if(root != null)
        {
            if(isLeft)
            {
                sb.Append(root.val);
                IsSymmetricTreeRecursion(root.left, sb, true);
                IsSymmetricTreeRecursion(root.right, sb, true);
            }
            else
            {
                sb.Append(root.val);
                IsSymmetricTreeRecursion(root.right, sb, false);
                IsSymmetricTreeRecursion(root.left, sb, false);
            }
        }
        else
            sb.Append("null");
    }
    
}