public class Solution 
{
    public int FindJudge(int n, int[][] trust) 
    {
        if(trust.Length == 0 && n == 1)
            return 1;
                
        // because the values seem to be 1 based instead of 0
        int[] trustCounts = new int[n+1];
        
        foreach(var trusts in trust)
        {
            trustCounts[trusts[0]] = Int32.MinValue;
            trustCounts[trusts[1]] += 1;
        }
        
        int toReturn = -1;
        for(int i = 1; i <= n; i++)
        {
            if(trustCounts[i] == n-1)
            {
                if(toReturn != -1)
                    return -1;
                else
                    toReturn = i;
            }
        }
        return toReturn;
    }
}