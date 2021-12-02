public class Solution 
{
    public int Rob(int[] nums) 
    {
        if(nums.Length == 1)
            return nums[0];
        
        
        // contains the most money if there are only i houses (given i index)
        int[] dp = new int[nums.Length];
        
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);
        
        for(int i = 2; i < nums.Length; i++)
        {
            dp[i] = Math.Max(dp[i-2] + nums[i], dp[i-1]);
        }
        
        return dp[nums.Length-1];
    }
}