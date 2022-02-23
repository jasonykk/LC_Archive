public class Solution 
{
    public int FixedPoint(int[] arr) 
    {
        /*
        binary search this?        
        */
                
        int low = 0;
        int high = arr.Length - 1;
        
        // default is nothing is found
        int answer = -1;
        
        while (low <= high) 
		{
            // better to avoid the overflow
            int mid = low + (high - low) / 2;
            
            // if mid matches the value in the array, we're done
            if(mid == arr[mid])
            {
                answer = mid;
                // we still need to search down as we must return the smallest index
                high = mid - 1;
            }
            else if (mid > arr[mid])
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        
        // return whatever the answer may be
        return answer;
        
        
    }
}