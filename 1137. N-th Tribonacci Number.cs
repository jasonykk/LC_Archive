public class Solution 
{
    int[] dp = new int[38];
    
    public int Tribonacci(int n) 
    {
        // bottom up approach
        if(n <= 1)
            return n;
        
        if(n == 2)
            return 1;
        
        // Set starting dp values if we haven't done it
        if(dp[1] != 1)
        {
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 1;
        }
        
        // move upwards based on values we already know
        for(int i = 3; i <= n; i++)
        {
            dp[i] = dp[i-1] + dp[i-2] + dp[i-3];
        }
        
        return dp[n];
    }
    
    public int Tribonacci_TopDown(int n) 
    {
        if(n <= 1)
            return n;
        
        if(n == 2)
            return 1;
        
        // Set starting dp values if we haven't done it
        if(dp[1] != 1)
        {
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 2;
        }
        
        if(dp[n] != 0)
            return dp[n];
        else
        {
            dp[n] = Tribonacci(n-1) + Tribonacci(n-2) + Tribonacci(n-3);
        }
        
        return dp[n];
    }
    
    public int Tribonacci_Recursive(int n) 
    {
        if(n <= 1)
            return n;
        
        if(n == 2)
            return 1;
        
        return Tribonacci(n-1) + Tribonacci(n-2) + Tribonacci(n-3);
    }
}