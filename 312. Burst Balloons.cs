public class Solution 
{
    public int MaxCoins(int[] nums) 
    {
        /*
        See Approach 2 for a very good breakdown of the dp Top down approach
        https://leetcode.com/problems/burst-balloons/solution/
        */
        
        // add val 1 at start/end of the nums array
        
        int[] expandedNums = new int[nums.Length + 2];
        // set 1 at start
        expandedNums[0] = 1;
        // copy nums
        Array.Copy(nums, 0, expandedNums, 1, nums.Length);
        // set 1 at the end
        expandedNums[expandedNums.Length - 1] = 1;
                
        int[,] memo = new int[expandedNums.Length, expandedNums.Length];
        
        // 0th and last position are not real numbers. they aid in calculation only
        return DP(memo, expandedNums, 1, expandedNums.Length - 2);
    }
    
    public int DP(int[,] memo, int[] nums, int left, int right)
    {
        if(right - left < 0)
            return 0;
        
        if(memo[left, right] > 0)
            return memo[left, right];
        
        int maxCoins = 0;
        
        for(int i = left; i<= right; i++)
        {
            // assume i is the last ballon to be burst
            // we do it this way to ensure we don't have to consider the order in which things are burst when dividing and condquering left and right subarrays            
            int coinsGained = nums[left - 1] * nums[i] * nums[right + 1];
            
            int remainder = DP(memo, nums, left, i - 1) + DP(memo, nums, i + 1, right);
            maxCoins = Math.Max(maxCoins, coinsGained + remainder);
        }
        
        memo[left, right] = maxCoins;
        return maxCoins;
    }
    
}