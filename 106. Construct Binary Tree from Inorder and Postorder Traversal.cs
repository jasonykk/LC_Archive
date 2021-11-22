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
    public TreeNode BuildTree(int[] inorder, int[] postorder) 
    {
        /*
        Notes:
        The last val in postorder contains the root node
        Anything left of it in inorder is in the left subtree
        A complete subtree of left, root, right can be found if in order vals exists in the same 3 in postorder
            EG: inorder: 4 2 5
                postorder: 4 5 2
        
        Helper methods:
        ProcessLeftSubtree
            Find the next root node given the current array
        ProcessRightSubtree
        
        CreateTree
            Find the root (start with last val in PostOrder)
            Everything left of said val in InOrder is in the leftSubtree
            Grab it's associated values in the same order, from PostOrder
            Call Create Tree (recursive)
                on return we have everything in the left tree (at least 1 node)
                we now need to create the right subtree
                Everything right of val in InOrder is in the rightSubtree
                Grab it's associated values in the same order, from PostOrder                
        */
        var root = BuildTree(inorder, postorder, 0, inorder.Length - 1, 0, postorder.Length - 1);        
        return root;
    }
    
    
    public TreeNode BuildTree(int[] inorder, int[] postorder, int inorderStart, int inorderEnd, int postorderStart, int postorderEnd) 
    {  
        if(inorderStart > inorderEnd
          || postorderStart > postorderEnd)
            return null;
        
        int rootVal = postorder[postorderEnd];
        //Console.WriteLine($"rootVal:{rootVal},  inorderStart:{inorderStart},  inorderEnd:{inorderEnd},  postorderStart:{postorderStart},  postorderEnd:{postorderEnd}");
        TreeNode root = new TreeNode(rootVal);
        var inorderRootIndex = 0;
        for(int i = 0; i < inorder.Length; i++)
        {
            if(inorder[i] == rootVal)
            {
                inorderRootIndex = i;
                break;
            }
        }
        
        
        //Console.WriteLine("Calling left");
        // total number of nodes being considered by in order is inorderRootIndex-inorderStart-1
        // so the "end" for the postOrder is the starting point (postorderStart), ending in the same length inorderRootIndex-inorderStart-1
        root.left = BuildTree(inorder, postorder, inorderStart, inorderRootIndex-1, postorderStart, postorderStart+inorderRootIndex-inorderStart-1);
        
        //Console.WriteLine("Calling right");
        // new postorderEnd has to be old postorderEnd-1 since the last value is the current root value
        root.right = BuildTree(inorder, postorder, inorderRootIndex+1, inorderEnd, postorderStart+inorderRootIndex-inorderStart, postorderEnd - 1);
        
        return root;
        
    }
    
}