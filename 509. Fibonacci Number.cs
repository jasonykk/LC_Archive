public class Solution 
{
    Dictionary<int, int> dp = new Dictionary<int, int>();
    
    public int Fib(int n) 
    {
        if(n <= 1)
            return n;
        
        int x = 0;
        int y = 1;
        int count = 1;
        
        while(count != n)
        {
            int newVal = x + y;
            x = y;
            y = newVal;
            count += 1;
        }
                    
        return y;
        
    }
    
    public int Fib_DP(int n) 
    {
        if(n <= 1)
            return n;
        
        if(dp.ContainsKey(n))
            return dp[n];
        else
        {
            dp.Add(n, Fib(n-1) + Fib(n-2));
        }
                    
        return dp[n];
        
    }
    
    
    public int Fib_Basic(int n) 
    {
        if(n <= 1)
            return n;
        
        return Fib(n-1) + Fib(n-2);
        
    }
}