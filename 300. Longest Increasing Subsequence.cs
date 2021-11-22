public class Solution 
{
    public int LengthOfLIS(int[] nums) 
    {
        /*
        Considerations:
            we cannot finish this by solving smaller problems and immediately adding that if a smaller value is found
            there is no guarantee that the previous result (say i and i-1) will be valid with the new number
            for example: 0,1,2,3,0,1
            as we add up to 3, we get a count of 4. 0 does not increase the count and while 1 is bigger than 0, we shouldn't include it since 3 was the last largest number
        
        repeat calculations for each index and compare with all previous values
            reuse values ONLY if the previous value was less than the current value AND the count at that value is more than what we have
            
        great explanation at: https://www.youtube.com/watch?v=CE2b_-XfVDk
        
		Time is O(n^2) since we have 2 loops
		Space is O(n) given that we need a copy to save results over time
        */
        
            
        if(nums == null || nums.Length == 0)
            return 0;
        
        int[] maxPerIndex = new int[nums.Length];
        
        // prepopulate the values to 1. each index as a standalone will start a max of 1 since even if there is no increasing, they are a count of  1
        for(int i = 0; i < maxPerIndex.Length; i++)
        {
            maxPerIndex[i] = 1;
        }
        
        // start at 1 since 0 index will never be more than that
        for(int i = 1; i < nums.Length; i++)
        {
            for(int j = 0; j < i; j++)
            {
                if(nums[j] < nums[i])
                {
                    maxPerIndex[i] = Math.Max(maxPerIndex[i], maxPerIndex[j] + 1);
                }
            }
        }
        
        // now that we have the max counts per index, iterate over and see which is max
        int toReturn = Int32.MinValue;        
        foreach(var val in maxPerIndex)
        {
            toReturn = Math.Max(val, toReturn);
        }
        
        return toReturn;
        
        
    }
}