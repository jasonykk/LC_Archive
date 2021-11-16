public class Solution 
{
    public int MaxProfit(int[] prices) 
    {
        // mark the starting position when the value decreases (valley)
        // mark the position when the value goes up, keep marking as it increases (peak)
        // when the value decreases again, the difference is between the last marked and start is the profit
        // update start index to the newly decreased value and repeat
        
        if(prices == null || prices.Length == 0)
            return 0;
        
        int start = prices[0];
        int end = prices[0];
        int totalProfit = 0;
        // marks that we're looking for prices to increase (this is false at the start as we want to find a decrease)
        bool isIncreasing = false;
        
        for(int i = 1; i < prices.Length; i++)
        {
            if(isIncreasing)
            {
                if(prices[i] > end)
                {
                    end = prices[i];
                }
                else if(prices[i] < end)
                {
                    // if prices go down, the previous marked one was the highest so we have profit
                    totalProfit += (end - start);
                    // update to the current price for start/end
                    start = prices[i];
                    end = prices[i];   
                }
            }
            else
            {
                if(prices[i] < start)
                {
                    // update to the current price for start/end
                    start = prices[i];
                    end = prices[i];   
                    isIncreasing = true;
                }
                else if(prices[i] > start)
                {
                    // if the value increased before decreasing, start was a good "start"
                    end = prices[i]; 
                    isIncreasing = true;
                }
            }
        }
        
        // if we never found a value that was increasing, it increased the entire way. so the profit is last - first        
        if(!isIncreasing)
            return prices[prices.Length - 1] - start;
        
        // if we reach the end increasing, we can add in the last profit
        if(start != end)
            totalProfit += (end - start);
        
        return totalProfit;
        
    }
}