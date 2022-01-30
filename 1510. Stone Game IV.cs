public class Solution 
{
    public bool WinnerSquareGame(int n) 
    {
        Dictionary<int, bool> results = new Dictionary<int, bool>();
        results.Add(0, false);
        return dfs(results, n);        
    }
    
    public bool dfs(Dictionary<int, bool> results, int remainder)
    {
        if(results.ContainsKey(remainder))
        {
            return results[remainder];
        }
        
        int sqrRootVal = (int)Math.Sqrt(remainder);
        
        for(int i = 1; i <= sqrRootVal; i++)
        {
            if(!dfs(results, remainder - (i * i)))
            {
                results.Add(remainder, true);
                return true;
            }
        }
        
        results.Add(remainder, false);
        return false;
        
    }
    
}