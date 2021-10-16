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
    List<int> toReturn = new List<int>();
    
    public IList<int> PostorderTraversal(TreeNode root) 
    {
        // postorder traversal -> left, right, root        
        
        if(root == null)
            return toReturn;
        
        var nodeStack = new Stack<TreeNode>();
        nodeStack.Push(root);
        TreeNode prevNode =  null;
        
        
        while(nodeStack.Count() > 0)
        {
            var currentNode = nodeStack.Peek();
            
            // see if we're coming back up or we're at a leaf
            if ((currentNode.left == null && currentNode.right == null)
             || (prevNode != null && (prevNode == currentNode.left || prevNode == currentNode.right)))
            {
                currentNode = nodeStack.Pop();
                toReturn.Add(currentNode.val); 
                prevNode = currentNode;                
            }
            else
            {
                // add in the right node
                if(currentNode.right != null)
                    nodeStack.Push(currentNode.right);
                
                if(currentNode.left != null)
                    nodeStack.Push(currentNode.left);
            }
        }
            
        return toReturn;
        
    }
        
    public IList<int> PostorderTraversalRecursion(TreeNode root) 
    {
        if(root != null)
        {
            PostorderTraversalRecursion(root.left);
            PostorderTraversalRecursion(root.right);
            toReturn.Add(root.val);
        }
        
        return toReturn;
        
    }
}