public class Solution 
{
    public void NextPermutation(int[] nums) 
    {
        /*
        Start from the end to front
        Find when the value decreases (we have a pivot point)
        Find the value after pivot that has the smallest difference to the pivot value
        Swap the values 
        Sort the remainder of the array
        
        If there is no value decrease, just sort and return
        */
        
        //optimizations
        if(nums.Length == 1)
            return;
        
        for(int i = nums.Length - 2; i >= 0; i--)
        {
            if(nums[i] < nums[i+1])
            {
                // we've found our pivot point
                // now locate the smallest value after the pivot that's larger than it (search from the last value again since we were only increasing in value up to pivot)
                int swapIndex = -1;
                for(int j = nums.Length - 1; j > i; j--)
                {
                    var currentDifference = nums[j] - nums[i];
                    if(currentDifference > 0)
                    {
                        swapIndex = j;
                        break;
                    }
                }
                
                // swap the value with the pivot
                var tempValue = nums[i];
                nums[i] = nums[swapIndex];
                nums[swapIndex] = tempValue;
                
                // sort the array AFTER the pivot point
                Array.Reverse(nums, i+1, nums.Length - i - 1);
                
                // return as we're done
                return;
            }
        }
        
        // if we reach this point, that means that the values kept increasing and its the max iteration
        // sort and we're done
        Array.Reverse(nums);
        
    }
}