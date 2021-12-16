public class Solution 
{
    public int MaxProduct(int[] nums) 
    {
        int minVal = nums[0];
        int maxVal = nums[0];
        int toReturn = nums[0];
        
        
        for(int i = 1; i < nums.Length; i++)
        {
            var currentNum = nums[i];
            // update values
			// we always calculate the max and min value (including the value itself). This helps when we encounter a negative value, followed by another
			// since a negative value will make the max the min, the reverse is also true as the smallest value * a negative will make it the largest
			// 0 is also fine as it'll "reset" everything
            var tempMin = Math.Min(currentNum, Math.Min(currentNum * minVal, currentNum * maxVal));
            var tempMax = Math.Max(currentNum, Math.Max(currentNum * minVal, currentNum * maxVal));
            
			// we use temp variables so we don't mess up the calculations for comparison and saving
            minVal = tempMin;
            maxVal = tempMax;
            toReturn = Math.Max(toReturn, maxVal);            
        }
                     
        return toReturn;
    }
}