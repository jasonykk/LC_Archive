/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution 
{    
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) 
    {
        /*
        Given that its a typical binary tree and not a BST, there is no guarantee to ordering
        iterate from the root and we form a hashset containing the tree of the left and right subtrees of a given node
        if the union of the trees + the current node gives true (p and q exists) we can stop looking and bubble up the node
        */
        
        return FindLCA(root, p, q).Item1;
            
    }
    
    public Tuple<TreeNode, HashSet<TreeNode>> FindLCA(TreeNode node, TreeNode p, TreeNode q) 
    {
        if(node == null)
            return new Tuple<TreeNode, HashSet<TreeNode>>(null, new HashSet<TreeNode>());
                
        // check the children
        var leftCheck = FindLCA(node.left, p, q);
        if(leftCheck.Item1 != null)
            return leftCheck;
        
        var rightCheck = FindLCA(node.right, p, q);
        if(rightCheck.Item1 != null)
            return rightCheck;
        
        // its not in left/right child trees
        var currentTree = leftCheck.Item2;
        currentTree.UnionWith(rightCheck.Item2);
        currentTree.Add(node);
        
        if(currentTree.Contains(p) && currentTree.Contains(q))
            return new Tuple<TreeNode, HashSet<TreeNode>>(node, currentTree);
        else
            return new Tuple<TreeNode, HashSet<TreeNode>>(null, currentTree);
    }
}