public class Solution 
{
    public IList<IList<int>> ThreeSum(int[] nums) 
    {
        // sort the array first, this allows us to clearly save the string for hashing purposes to detect dupes
        
        List<IList<int>> toReturn = new List<IList<int>>();
        Array.Sort(nums);
        
        // now that the array is sorted, we can iterate over it, ensuring that we have low and high pointers (fastest way to get to 0)
        for(int i = 0; i < nums.Length - 2; i++)
        {
            int currentNum = nums[i];
            // always start with 0, but after that we should "start" with a different number. 
            // the combinations with the same number will not change!
            if((i == 0) || (i > 0 && nums[i] != (nums[i-1])))
            {
                int lowVal = i + 1;
                int highVal = nums.Length - 1;
                int requiredNum = 0 - currentNum;
                
                // check all combinations for 0
                while(lowVal < highVal)
                {
                    if(nums[lowVal] + nums[highVal] == requiredNum)
                    {
                        toReturn.Add(new List<int>{currentNum, nums[lowVal], nums[highVal]});
                        // iterate until we have a new combination for lowVal and highVal
                        while(lowVal < highVal && nums[lowVal] == nums[lowVal+1])
                        {
                            lowVal += 1;
                        }
                        while(lowVal < highVal && nums[highVal] == nums[highVal-1])
                        {
                            highVal -= 1;
                        }
                        // we must decrement 1 more time as our check was for equal values up to the next value
                        lowVal += 1;
                        highVal -= 1;
                    }
                    else if(nums[lowVal] + nums[highVal] < requiredNum)
                    {
                        // we are under the required amount, so we need to increase the low value
                        while(lowVal < highVal && nums[lowVal] == nums[lowVal+1])
                            lowVal += 1;
                        // we must decrement 1 more time as our check was for equal values up to the next value
                        lowVal += 1;
                    }
                    else
                    {
                        // we are over the required amount, so we need to decrease the high value
                        while(lowVal < highVal && nums[highVal] == nums[highVal-1])
                            highVal -= 1;
                        // we must decrement 1 more time as our check was for equal values up to the next value
                        highVal -= 1;
                    }
                }
            }
            
            // if the values in the array have exceeded 0, there's no way to get a sum of 0 anymore as we need negative numbers
            if(nums[i] > 0)
                break;
        }
        
        return toReturn;
        
    }
}