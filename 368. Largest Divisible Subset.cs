public class Solution 
{
    /*
    See https://leetcode.com/problems/largest-divisible-subset/discuss/1578991/C%2B%2B-4-Simple-Solutions-w-Detailed-Explanation-or-Optimizations-from-Brute-Force-to-DP
    For BruteForce, it's important to know that we do not need to compare with smaller values (assuming nums is sorted) of the previously chosen subset
        REASON: given the subset is already always divisible previously, we only need to compare with the last value
        EG: [1,2,6] and new value is 12, we should only need to compare 6 and 12
            what if [1,2,10] and value is 20, it'll follow for 2 and 1 too.
    
    */
    
    Dictionary<int, List<int>> resultLookup;
    
    public IList<int> LargestDivisibleSubset(int[] nums) 
    {
        List<int> toReturn = new List<int>();
        
        // initialize and populate the bare lookup
        resultLookup = new Dictionary<int, List<int>>();
        for(int i = 0; i < nums.Length; i++)
        {
            resultLookup.Add(i, new List<int>());
        }
        
        // sort the array so that we can take advantage of the last value comparison
        Array.Sort(nums);
        
        // try and brute force each value
        for(int i = 0; i < nums.Length; i++)
        {
            // now try looking at the rest of the index assuming value is picked 
            var resultsIfPicked = Helper(nums, i);
            // if we get a longer subset from choosing this value, replace it
            if(resultsIfPicked.Count > toReturn.Count)
                toReturn = resultsIfPicked;
        }
        
        return toReturn;
        
    }
    
    public List<int> Helper(int[] nums, int index) 
    {
        if(index >= nums.Length)
            return new List<int>();
        
        if(resultLookup.ContainsKey(index) && resultLookup[index].Count > 0)
            return resultLookup[index];
                        
        // try and brute force each value
        for(int i = index+1; i < nums.Length; i++)
        {
            if(nums[i] % nums[index] == 0)
            {
                // now try looking at the rest of the index assuming value is picked 
                var resultsIfPicked = Helper(nums, i);
                // if we get a longer subset from choosing this value, replace it
                if(resultsIfPicked.Count >= resultLookup[index].Count)
                    resultLookup[index] = resultsIfPicked.ToList();
            }
        }
        
        // add the chosen index value. We do not add it earlier as it'll skew the count of resultsIfPicked since we don't pass it down
        resultLookup[index].Add(nums[index]);
        
        return resultLookup[index];
        
        
    }
    
}