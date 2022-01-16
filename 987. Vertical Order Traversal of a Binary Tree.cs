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
    // level -> left/right -> node
    SortedDictionary<int, SortedDictionary<int, List<int>>> levelOrder;
    
    public IList<IList<int>> VerticalTraversal(TreeNode root) 
    {
        levelOrder = new SortedDictionary<int, SortedDictionary<int, List<int>>>();
        PopulateLevelOrder(root, 0, 0);
        
        List<IList<int>> toReturn = new List<IList<int>>();
        foreach(var kvp in levelOrder)
        {
            var currentLevel = new List<int>();
            foreach(var nodesKvp in kvp.Value)
            {
                nodesKvp.Value.Sort();
                currentLevel.AddRange(nodesKvp.Value);
            }
            toReturn.Add(currentLevel);
        }
        
        return toReturn;
    }
    
    public void PopulateLevelOrder(TreeNode node, int rightCount, int level)
    {
        if(node == null)
            return;
            
        // add the current value
        if(levelOrder.TryGetValue(rightCount, out var currentLevelsAndNodes))
        {
            if(currentLevelsAndNodes.TryGetValue(level, out var currentNodes))
            {
                currentNodes.Add(node.val);
            }
            else
            {
                var newNodeList = new List<int>();
                newNodeList.Add(node.val);
                currentLevelsAndNodes.Add(level, newNodeList);
            }
        }
        else
        {
            var newNodeList = new List<int>();
            newNodeList.Add(node.val);
            SortedDictionary<int, List<int>> valueLookup = new SortedDictionary<int, List<int>>();
            valueLookup.Add(level, newNodeList);
            levelOrder.Add(rightCount, valueLookup);
        }
        
        // go left
        PopulateLevelOrder(node.left, rightCount-1, level+1);
        
        // go right
        PopulateLevelOrder(node.right, rightCount+1, level+1);
        
        
        
    }
    
}