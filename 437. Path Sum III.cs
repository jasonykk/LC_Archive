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
    public int toReturn;
    public int savedTargetSum;
    
    public int PathSum(TreeNode root, int targetSum) 
    {
        // Calculate the value as we traverse the tree
        // We must include all combinations coming down the path (use an array)
        // each node we use array.Length + 1
        // when the value matches the target, we increment global counter
        
        if(root == null)
            return 0;
        
        toReturn = 0;
        savedTargetSum = targetSum;
        PathSumRecursion(root, new int[0]);
        return toReturn;
    }
    
    
    public void PathSumRecursion(TreeNode node, int[] arr) 
    {
        if(node == null)
            return;
        
        // add the currentNode value to arr
        int[] currentVals = new int[arr.Length + 1];
        int baseValue = node.val;
        // add the current value to every other sum we've gotten to this point
        for(int i = 0; i < arr.Length; i++)
        {
            int currentVal = arr[i] + baseValue;
            currentVals[i] = currentVal;
            if(currentVal == savedTargetSum)
                toReturn += 1;
        }
        // the last value in the new array is the current value itself
        currentVals[currentVals.Length - 1] = baseValue;
        if(baseValue == savedTargetSum)
            toReturn += 1;
        
        // recurse to children of node
        PathSumRecursion(node.left, currentVals);
        PathSumRecursion(node.right, currentVals);
        
    }
    
}