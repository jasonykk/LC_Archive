public class Solution 
{
    public int FindPairs(int[] nums, int k) 
    {
        // sort the array
        // go through the array and see if we can find the needed value in the Hashset
        
        // optimization: since we're talking about absolute difference, we cannot get a negative number regardless of the combination
        if (k < 0)
            return 0;
        
        HashSet<int> lookup = new HashSet<int>();
        HashSet<int> repeated = new HashSet<int>();
        int toReturn = 0;
        
        for(int i = nums.Length - 1; i >= 0; i--)
        {
            var currentVal = nums[i];
            if(lookup.Contains(currentVal))
            {
                repeated.Add(currentVal);
            }
            else
            {
                lookup.Add(currentVal);
            }  
        }
        
        if(k == 0)
            return repeated.Count;
        else
        {
            // go through all unique values we found and see if the associated value exists in it (through val + k)
            foreach(var val in lookup)
            {
                if(lookup.Contains(val + k))
                    toReturn += 1;
            }
        }
        
        
        return toReturn;
        
    }
    
}