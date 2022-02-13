public class Solution 
{
    public int SubarraySum(int[] nums, int k) 
    {
        int totalElements = nums.Length;
        int currentSum = 0;
        int found = 0;
        Dictionary<int, int> valueLookup = new Dictionary<int, int>();
        // by default, we can always assume that 0 is present since we can find k inside the sums
        valueLookup.Add(0, 1);
        
        // get the sum of each from 0th element
        for(int i = 0; i < totalElements; i++)
        {
            currentSum += nums[i];
            
            // see if the required value (current - k) exists, and if so, add that to the found count
            if(valueLookup.TryGetValue(currentSum - k, out var count))
            {
                found += count;
            }
            
            // save the new sum as a possible value
            if(valueLookup.ContainsKey(currentSum))
            {
                valueLookup[currentSum] += 1;
            }
            else
            {
                valueLookup.Add(currentSum, 1);
            }
        }
        
        return found;        
    }
}