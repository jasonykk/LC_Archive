public class SparseVector 
{
    public Dictionary<int, int> populatedValues;
    int n;
    
    public SparseVector(int[] nums) 
    {
        populatedValues = new Dictionary<int, int>();
        n = nums.Length;
        
        // O(n) run time since we go through it once, O(n) space at worse case if everything is not 0
        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] != 0)
            {
                populatedValues.Add(i, nums[i]);
            }
        }
    }
    
    // Return the dotProduct of two sparse vectors
    public int DotProduct(SparseVector vec) 
    {
        int toReturn = 0;
        
        // O(n) worst case but we can tag this as O(k), k being how many valid values earlier. O(1) for lookup and multiplication
        foreach(var kvp in populatedValues)
        {
            // we only multiply by values we found in this vector (it would be 0 otherwise even if the incoming vector has a value)
            int currentValue = 0;
            if(vec.populatedValues.TryGetValue(kvp.Key, out currentValue))
                toReturn += currentValue * kvp.Value;
        }        
        
        return toReturn;
        
    }
}

// Your SparseVector object will be instantiated and called as such:
// SparseVector v1 = new SparseVector(nums1);
// SparseVector v2 = new SparseVector(nums2);
// int ans = v1.DotProduct(v2);