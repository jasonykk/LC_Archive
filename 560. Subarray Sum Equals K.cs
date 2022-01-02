public class Solution 
{
    public int SubarraySum(int[] nums, int k) 
    {
        int[] sumSoFar = new int[nums.Length];
        int totalElements = nums.Length;
        int found = 0;
        
        // get the sum of each from 0th element
        for(int i = 0; i < totalElements; i++)
        {
            int prev = 0;
            if(i > 0)
                prev = sumSoFar[i-1];
            sumSoFar[i] = nums[i] + prev;
            
            if(sumSoFar[i] == k)
                found += 1;                
        }
        
        // see if any subarrays has the value
        for(int i = 0; i < totalElements; i++)
        {
            for(int j = i+1; j < totalElements; j++)
            {
                if(sumSoFar[j] - sumSoFar[i] == k)
                    found += 1;
            }
        }
        
        return found;        
    }
}