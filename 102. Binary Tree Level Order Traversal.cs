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
    public IList<IList<int>> LevelOrder(TreeNode root) 
    {
        // use a queue
        // keep adding all child nodes to the queue, and finish with a "breaker" node
        // finish when the queue is empty
        
        List<IList<int>> toReturn = new List<IList<int>>();
        
        if(root == null)
            return toReturn;
        
        
        
        Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
        var breakerNode = new TreeNode(Int32.MaxValue);
        nodeQueue.Enqueue(root);
        nodeQueue.Enqueue(breakerNode);
        var currentLevel = new List<int>();
        
        while(nodeQueue.Count() > 0)
        {
            var currentNode = nodeQueue.Dequeue();
            
            if(currentNode == null)
            {
                continue;
            }
            if(currentNode != breakerNode)
            {
                currentLevel.Add(currentNode.val);
                nodeQueue.Enqueue(currentNode.left);
                nodeQueue.Enqueue(currentNode.right);
            }
            else
            {
                // we've reached a breaker node, add it back in or exit if its the last thing
                if(nodeQueue.Count() == 0)
                    break;
                else
                {
                    nodeQueue.Enqueue(breakerNode);
                    // add the level results and reset
                    toReturn.Add(currentLevel);
                    currentLevel = new List<int>();
                }
                
            }
        }
        
        return toReturn;
        
        
    }
}