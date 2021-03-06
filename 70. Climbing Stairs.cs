public class Solution 
{
    public int ClimbStairs(int n) 
    {
        if(n == 0)
            return 0;
        if(n == 1)
            return 1;
        if(n == 2)
            return 2;
        
        int[] dp = new int[n+1];
        dp[0] = 0;
        dp[1] = 1;
        dp[2] = 2;
        
        for(int i = 3; i <= n; i++)
        {
            dp[i] = dp[i-1] + dp[i-2];
        }
        
        return dp[n];
        
    }
    
    
    public int ClimbStairs2(int n) 
    {
        if(n == 0)
            return 0;
        if(n == 1)
            return 1;
        if(n == 2)
            return 2;
        
        int singleStep = 2;
        int twoSteps = 1;
        int toReturn = 0;
        
        for(int i = 2; i < n; i++)
        {
            toReturn = singleStep + twoSteps;
            twoSteps = singleStep;
            singleStep = toReturn;
        }
        
        return toReturn;
        
    }
}