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
    public TreeNode DeleteNode(TreeNode root, int key) 
    {
        /*
        Traverse the tree to find the node.
        IF found, we need to find two pieces of information:
            - rightmost node of the left subtree
            put it in place of the removed node
                - we need the parent of said node too since we must now null out the connection
        
        */
        
        root = DeleteNodeHelper(root, key);
        return root;
    }
    
    
    public TreeNode DeleteNodeHelper(TreeNode node, int key) 
    {
        if(node == null)
            return null;
        
        if(node.val == key)
        {
            // if there are no child nodes, we return null since nothing replaces it
            if(node.left == null && node.right == null)
            {
                return null;
            }            
            else if(node.left == null && node.right != null)
            {
                // if we only have a right subtree, return that directly
                return node.right;
            }      
            else if(node.left != null && node.right == null)
            {
                // if we only have a left subtree, return that directly
                return node.left;
            }
            else
            {
                // if there is both left and right subtrees, replace with the smallest value in the right subtree (that is the next val that can replace current node)
                
                var currentNode = node.right;
                var prevNode = node;
                bool moved = false;
                while(currentNode.left != null)
                {
                    moved = true;
                    prevNode = currentNode;
                    currentNode = currentNode.left;
                }
                
                if(moved)
                {
                    // now that we found the node, remove reference to this node from its parent and set to the "right" node if any
                    prevNode.left = currentNode.right;
                }
                
                // set the node's decendants to be existing node's
                if(node.left.val != currentNode.val)
                    currentNode.left = node.left;
                if(node.right.val != currentNode.val)
                    currentNode.right = node.right;
                
                return currentNode;
            }
        }
        else if(node.val > key)
        {
            // we are larger, move left
            node.left = DeleteNodeHelper(node.left, key);
        }
        else
        {
            // we are smaller, move right
            node.right = DeleteNodeHelper(node.right, key);
        }
                
        return node;
    }
    
}