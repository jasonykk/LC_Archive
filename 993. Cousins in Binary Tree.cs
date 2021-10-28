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
    public bool IsCousins(TreeNode root, int x, int y) 
    {
        // do a BFS approach? if in the same 
        // we must keep track of the current level
        // if root is depth/level 0, answers can only be found > level 1
        // we want to end as early as possible so that we don't have to scan the whole tree (if possible)
        
        if(root == null)
            return false;
        
        TreeNode breakerNode = null;
        Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
        nodeQueue.Enqueue(root);
        nodeQueue.Enqueue(breakerNode);
        int firstFoundLevel = 0;
        TreeNode firstFoundParent = null;
        int currentLevel = 0;
        
        while(nodeQueue.Count > 0)
        {
            var currentNode = nodeQueue.Dequeue();
            
            if(currentNode != breakerNode)
            {
                // add children if present
                if(currentNode.left != null)
                {
                    if(currentNode.left.val == x)
                    {
                        if(firstFoundLevel == 0)
                        {
                            firstFoundLevel = currentLevel;
                            firstFoundParent = currentNode;
                        }
                        else
                        {
                            // see if we found Y previously and compare parents and level
                            if(currentLevel == firstFoundLevel
                              && currentNode != firstFoundParent)
                                return true;
                            else
                                return false;
                        }
                    }
                    else if(currentNode.left.val == y)
                    {
                        if(firstFoundLevel == 0)
                        {
                            firstFoundLevel = currentLevel;
                            firstFoundParent = currentNode;
                        }
                        else
                        {
                            // see if we found X previously and compare parents and level
                            if(currentLevel == firstFoundLevel
                              && currentNode != firstFoundParent)
                                return true;
                            else
                                return false;
                        }
                    }
                    nodeQueue.Enqueue(currentNode.left);
                }
                if(currentNode.right != null)
                {
                    if(currentNode.right.val == x)
                    {
                        if(firstFoundLevel == 0)
                        {
                            firstFoundLevel = currentLevel;
                            firstFoundParent = currentNode;
                        }
                        else
                        {
                            // see if we found Y previously and compare parents and level
                            if(currentLevel == firstFoundLevel
                              && currentNode != firstFoundParent)
                                return true;
                            else
                                return false;
                        }
                    }
                    else if(currentNode.right.val == y)
                    {
                        if(firstFoundLevel == 0)
                        {
                            firstFoundLevel = currentLevel;
                            firstFoundParent = currentNode;
                        }
                        else
                        {
                            // see if we found X previously and compare parents and level
                            if(currentLevel == firstFoundLevel
                              && currentNode != firstFoundParent)
                                return true;
                            else
                                return false;
                        }
                    }
                    nodeQueue.Enqueue(currentNode.right);
                }
            }
            else
            {
                // we're done with the level, increment and add a breakerNode if we're not done
                if(nodeQueue.Count > 0)
                    nodeQueue.Enqueue(breakerNode);
                currentLevel += 1;
            }
            
        }
        
        return false;
        
        
        
    }
        
    
}