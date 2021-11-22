public class Solution 
{
    public int SingleNonDuplicate(int[] nums) 
    {
        /*
        Given that there every number appears twice, except one, we should be able to compare every numbered indexed pair
        aka num[0] == num[1], num[2] == num[3]
        if at any point in time, the even does not equal to the odd, a number was missed already
        - trick is now to use binary search.
            when we find a mid point, see if the even mid point matches the odd mid point
            if it does, the "missing" value is on the right of it
            if it does not, the "missing" value is on the left of it        
        */
        
        // if there is only one value, return immediately
        if(nums.Length == 1)
            return nums[0];
        
        int start = 0;
        int end = nums.Length - 1;
        
        while(start < end)
        {
            // we want mid to be in an even position.
            int mid = (start + end) / 2;
            
            // while starting out we are always going to have a proper "mid", as we move we may not be on an even position
            if(mid % 2 != 0)
                mid -= 1;
            
            if(nums[mid] == nums[mid+1])
            {
                // we have not missed anything, search right
                start = mid + 2;
            }
            else
            {
                // we have missed something, search left
                end = mid;
            }
        }
        
        return nums[start];
        
    }
}