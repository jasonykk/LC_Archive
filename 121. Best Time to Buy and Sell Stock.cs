public class Solution 
{
    public int MaxProfit(int[] prices) 
    {
        // seems like a moving window problem (only go from left to right)
        // start begin and end indexes at the start, keep going until we find the biggest difference. 
        // then move start and see if we can find something bigger
        // continue until end is reached.
        
        if(prices.Length == 0)
            return 0;
        
        int min = prices[0];
        int max = 0;
        int currentDiff = 0;
        
        for(int i = 1; i < prices.Length; i++)
        {
            currentDiff = prices[i] - min;
            max = Math.Max(max, currentDiff);
            min = Math.Min(min, prices[i]);
        }
        
        return max;
        
        
    }
}