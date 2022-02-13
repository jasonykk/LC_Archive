public class Solution 
{
    public int FindMaxLength(int[] nums) 
    {
        /*
        We'll use counts for equality based on 0s and 1s. Increase when 1, decrease when 0
        If we ever get back to 0, we know that from the 0th index to current index, that length has the same number of 0s and 1s
        However, its unlikely this is the case. So, if we find the SAME COUNT multiple times, the range between them is the length
            THisis because between the first time we saw a count, to the current time has the same # of 0s and 1s
            So we only need to save the first time we see a count for future length calculations
        
        */
        
        Dictionary<int, int> valueLookup = new Dictionary<int, int>();
        valueLookup.Add(0, -1);
        int maxLength = 0;
        int count = 0;
        
        for(int i = 0; i < nums.Length; i++)
        {
            // increase the count if its 1, decrease if its 0
            int currentCount = nums[i] == 1 ? 1 : -1;
            count += currentCount;
            
            if(valueLookup.TryGetValue(count, out var previousIndex))
            {
                // the length we'd want to count is from the current index (i) to the previously saved one
                // we then see if this length is longer than the one we saved before
                maxLength = Math.Max(maxLength, i - previousIndex);
            }
            else
            {
                // we save the first time we find a count
                valueLookup.Add(count, i);
            }
        }
        
        
        return maxLength;
    }
}