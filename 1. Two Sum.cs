public class Solution 
{
    public int[] TwoSum(int[] nums, int target) 
    {
        // use a Dictionary to save the target - nums[i] value as key and the i as value. If it exists, we have found it
        var lookup = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            if(lookup.ContainsKey(num))
                return new int[2] { i, lookup[num] };
            else
            {
                if(!lookup.ContainsKey(target - num))
                    lookup.Add(target - num, i);       
            }
                         
        }
        return new int[0];
    }
}