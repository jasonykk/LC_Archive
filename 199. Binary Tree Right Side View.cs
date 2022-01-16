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
    public IList<int> RightSideView(TreeNode root) 
    {
        /*
        BFS the entire tree, the last node per level is added to the results.
        */
        
        List<int> toReturn = new List<int>();
        
        if(root == null)
            return toReturn;
        
        // setup queue for BFS
        Queue<TreeNode> toProcess = new Queue<TreeNode>();
        // create a breaker node so we can keep track when a level has ended
        TreeNode breakerNode = new TreeNode(Int32.MinValue);
        
        toProcess.Enqueue(root);
        toProcess.Enqueue(breakerNode);
        TreeNode prevNode = null;
        
        while(toProcess.Count > 0)
        {
            var currentNode = toProcess.Dequeue();
            if(currentNode == breakerNode)
            {
                toReturn.Add(prevNode.val);
                
                // if there is still anything left in the queue, add a new breaker node as there are no more nodes for the next level
                if(toProcess.Count > 0)
                {
                    toProcess.Enqueue(breakerNode);
                }
            }
            else
            {
                // add the node's child nodes
                if(currentNode.left != null)
                    toProcess.Enqueue(currentNode.left);
                if(currentNode.right != null)
                    toProcess.Enqueue(currentNode.right);
                
                // update prevNode to the new node
                prevNode = currentNode;
            }
            
        }
        
        return toReturn;
        
    }
}