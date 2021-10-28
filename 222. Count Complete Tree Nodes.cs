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
    public int leafNodeLevel= Int32.MinValue;
    public int leafNodeNums = 0;
    
    public int CountNodes(TreeNode root) 
    {
        
        // calculate the height by moving all the way to the left
        var left = root;
        int leftHeight = 0;
        while(left != null)
        {
            leftHeight += 1;
            left = left.left;
        }
        
        // calculate the height by moving all the way to the right
        var right = root;
        int rightHeight = 0;
        while(right != null)
        {
            rightHeight += 1;
            right = right.right;
        }
        
        // if the heights are equal, its a full complete tree and we can return immediately
        if(leftHeight == rightHeight)
            return (int)Math.Pow(2, leftHeight) - 1;
        else
        {
            //if the heights are not even, we must now count the number of leaf nodes we have
            return CountNodes(root.left) + CountNodes(root.right) + 1;
        }       
        
    }
    
    public int CountNodesV1(TreeNode root) 
    {
        // at level n, we have 2^n - 1 nodes in total
        // root = level 1, 2^1 - 1 = 1
        // next = level 2, 2^2 - 1 = 3
        // next = level 3, 2^3 - 1 = 7
        // to find the total, we must find where the last leaf node is at the last level
        // once we have the total # of leaf nodes, we can add that to the previous level's node sum
        // explore from left-most since they are filled from the left-most side
        if(root == null)
            return 0;
        
        CountNodes(root, 1);
        // 2^n - 1
        var sumOfNodesInPriorLevel = Math.Pow(2, leafNodeLevel - 1) - 1;
        //Console.WriteLine($"leafNodeLevel:{leafNodeLevel},  leafNodeNums:{leafNodeNums},  sumOfNodesInPriorLevel:{sumOfNodesInPriorLevel}");
        return (int)(sumOfNodesInPriorLevel + leafNodeNums);
        
        
        
    }
    
    public bool CountNodes(TreeNode root, int level) 
    {
        // at level n, we have 2^n - 1 nodes in total
        // root = level 1, 2^1 - 1 = 1
        // next = level 2, 2^2 - 1 = 3
        // next = level 3, 2^3 - 1 = 7
        // to find the total, we must find where the last leaf node is at the last level
        // once we have the total # of leaf nodes, we can add that to the previous level's node sum
        // explore from left-most since they are filled from the left-most side
        
        //Console.WriteLine($"Current lvl:{level},  leafNodeNums:{leafNodeNums},  leafNodeLevel:{leafNodeLevel}, val:{root.val}");
                    
        if(root.left == null && root.right == null)
        {
            // we're at the leaf now, mark it if not yet found
            if(leafNodeLevel != Int32.MinValue && level < leafNodeLevel)
            {
                // if we find a leaf and it's not at the lowest level, we've found the last ever leaf node and can finish
                return true;            
            }
            else
            {
                if(leafNodeLevel == Int32.MinValue)
                {
                    leafNodeLevel = level;
                }
                // update the total number of lead nodes we've found
                leafNodeNums += 1;
            }
        }
        else
        {
            // keep going left
            if(root.left != null)
            {
                var foundLeft = CountNodes(root.left, level+1) ;
                if(foundLeft)
                    return true;
                else if(root.right != null)
                {
                    return CountNodes(root.right, level+1);
                }
            }
        }
        return false;
        
        
    }
    
    
    
}