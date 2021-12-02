public class Solution 
{
    public int MaximumScore(int[] nums, int[] multipliers) 
    {
        
        if(nums.Length == 1)
            return nums[0] * multipliers[0];
        
        PrintArr(nums);
        PrintArr(multipliers);
        
        // set trackers
        int n = nums.Length;
        int m = multipliers.Length;   
        // we use m + 1 as when we are at index m, we have no "previous" index to look at
        int[,] dp = new int[m+1,m+1];
        
        for(int i = m - 1; i >= 0; i--)
        {
            // for the given index, we search for all possible combinations of "left"
            for(int left = i; left >= 0; left--)
            {
                int currentMultiplier = multipliers[i];
                // rightmost is n-1, so we now need to know how much "right" we are given how many left we've taken.
                // eg: if we're at n = 5 and i = 3, and have taken 2 lefts, the current "right" to consider index-wise is, (5-1) - (3 - 2) == 4 - 1 == 3
                int right = (n-1) - (i - left);
                
                // we check left+1 because of the assumption that we pick the left product here
                int leftProduct = nums[left] * multipliers[i] + dp[i+1,left+1];
                // we check left as is because of the assumption that we pick from the right side (no change in left)
                int rightProduct = nums[right] * multipliers[i] + dp[i+1,left];
                
                dp[i,left] = Math.Max(leftProduct, rightProduct);
            }
        }       
        
        return dp[0,0];
    }
    
    
    public void PrintArr(int[] print)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("[");
        for(int i = 0; i < print.Length; i++)
        {
            
            sb.Append($"{print[i]},");
        }
        sb.Append("]");
        Console.WriteLine(sb.ToString());
    }
    
}