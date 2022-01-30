public class Solution 
{
    public bool ValidMountainArray(int[] arr) 
    {
        // 0 - not started, 1 - moving up, 2 - moving down
        int movement = 0;
        
        for(int i = 1; i < arr.Length; i++)
        {
            var diff = arr[i] - arr[i-1];
            if(diff > 0)
            {
                if(movement == 0)
                {
                    // mark that we're going up
                    movement += 1;
                }
                if(movement == 2)
                {
                    // we're supposed to be decreasing now.
                    return false;
                }
            }
            else if(diff == 0)
            {
                // we should be either increasing or decreasing
                return false;
            }
            else
            {
                // we're decreasing
                if(movement == 1)
                {
                    // set to true as this is the pivot
                    movement = 2;
                }
                else if(movement == 0)
                {
                    // if we have not moved up, this is false
                    return false;
                }
            }
            
        }
        
        if(movement == 2)
            return true;
        else
            return false;
        
    }
}