public class Solution 
{
    public int FindMaximumXOR(int[] nums) 
    {
        HashSet<int> uniqueValuesSet = new HashSet<int>();
        
        foreach(var num in nums)
        {
            uniqueValuesSet.Add(num);
        }
        
        var uniqueValues = uniqueValuesSet.ToArray();
        
        int maxVal = Int32.MinValue;
        for(int i = 0; i < uniqueValues.Length; i++)
        {
            for(int j = i; j < uniqueValues.Length; j++)
            {
                maxVal = Math.Max(maxVal, uniqueValues[i] ^ uniqueValues[j]);
            }
        }
        
        return maxVal;
    }
}