public class Solution 
{
    public int UniquePaths(int m, int n) 
    {
        // with dp, we have previous values as well being kept but never reused
        // try only keeping two rows, the first row (which always starts with 1s) and a new populated row
        int[] prevRow = new int[n];
        int[] currentRow = new int[n];
        
        // set the base values
        for(int i = 0; i < n; i++)
        {
            prevRow[i] = 1;
            // we can set currentRow as well since the only value we use immediately is from the first col which also always has val 1 only
            currentRow[i] = 1;
        }
        
        // start from 1 since we have the 0th values already
        for(int i = 1; i < m; i++)
        {
            for(int j = 1; j < n; j++)
            {
                // how many ways from the left and top (since we can only go right/down)
                currentRow[j] = prevRow[j] + currentRow[j-1];
            }
            // now that currentRow has been updated, clone it to prevRow before calculating the next row
            prevRow = (int[])currentRow.Clone();
        }
        
        return currentRow[n-1];
        
    }
    
    public int UniquePathsBasicDP(int m, int n) 
    {
        // all dp[0][col] and dp[row][0] has to be 1
        // this is due to movement being restricted to right and down only
        int[,] dp = new int[m,n];
        
        // set the base values
        for(int i = 0; i < m; i++)
        {
            dp[i, 0] = 1;
        }
        
        for(int i = 0; i < n; i++)
        {
            dp[0, i] = 1;
        }
        
        // start from 1 since we have the 0th values already
        for(int i = 1; i < m; i++)
        {
            for(int j = 1; j < n; j++)
            {
                // how many ways from the left and top (since we can only go right/down)
                dp[i,j] = dp[i, j-1] + dp[i-1, j];
            }
        }
        
        return dp[m-1, n-1];
        
    }
    
    
    
    public int UniquePathsCombination(int m, int n) 
    {
        // assume rights are 0 and downs are 1
        int rightCounts = n - 1;
        int downCounts = m - 1;
        
        // we now need to find how many unique combinations of rightCounts and downCounts we can do
        int objects = rightCounts + downCounts;
        int samples = rightCounts;
                
        // combination calculation is n! / (r! * (n-r)!)
        var result = Factorial(objects) / (Factorial(samples) * (Factorial(objects - samples)));
        
        return Convert.ToInt32(result);
        
    }
    
    public double Factorial(int val)
    {
        if(val <= 1)
            return 1;
        
        return val * Factorial(val-1);
    }
    
}