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
    Stack<TreeNode> t1;
    Stack<TreeNode> t2;
    
    public IList<int> GetAllElements(TreeNode root1, TreeNode root2) 
    {
        /*
        Do in order traversal for both trees, that way we guarantee that we go from small -> large for each
        
        */
        
        List<int> tree1Vals = new List<int>();
        List<int> tree2Vals = new List<int>();
        
        PrepareTreeValues(root1, tree1Vals);
        PrepareTreeValues(root2, tree2Vals);
        
        List<int> toReturn = new List<int>();
        
        int x = 0;
        int y = 0;
        
        while(x < tree1Vals.Count || y < tree2Vals.Count)
        {
            if(x >= tree1Vals.Count)
            {
                toReturn.Add(tree2Vals[y]);
                y += 1;
            }
            else if(y >= tree2Vals.Count)
            {
                toReturn.Add(tree1Vals[x]);
                x += 1;
            }
            else
            {
                if(tree1Vals[x] < tree2Vals[y])
                {
                    toReturn.Add(tree1Vals[x]);
                    x += 1;
                }
                else
                {
                    toReturn.Add(tree2Vals[y]);
                    y += 1;
                }
            }            
        }
        
            
        return toReturn;
    }
    
    public void PrepareTreeValues(TreeNode root, List<int> toReturn)
    {
        if(root == null)
            return;
        
        PrepareTreeValues(root.left, toReturn);
        toReturn.Add(root.val);
        PrepareTreeValues(root.right, toReturn);         
    }
    
}