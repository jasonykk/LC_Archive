public class Solution 
{
    public void SortColors(int[] nums) 
    {
        // have a current pointer iterating from start to end
        // check values and keep swapping with the "end" via an end index
        // once the pointers meet, reset the end and begin looking at the next value
        // worst case scenario this will be n^3 if there aren't any 0s or 1s (only 2s)
        
        int currentColor = 0;
        int ptr = 0;
        bool foundOne = false;
        
        // we finish when we're done with all colors ( we only need to swap 1s and 0s)
        while(currentColor <= 1)
        {
            int end = nums.Length - 1;
            
            while(ptr < end)
            {
                if(nums[ptr] == currentColor)
                {
                    ptr += 1;
                }
                else
                {
                    if(nums[end] == currentColor)
                    {
                        // swap the colors
                        nums[end] = nums[ptr];
                        nums[ptr] = currentColor;
                        ptr += 1;
                    }
                    end -= 1;
                }
            }      
            
            // final check to start after we're done with all the currentColor
            while(ptr < nums.Length && nums[ptr] == currentColor)
                ptr += 1;
            
            // we must increment the next color
            currentColor += 1;
        }
        
        
        
    }
}