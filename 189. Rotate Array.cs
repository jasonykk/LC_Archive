public class Solution 
{
    public void Rotate(int[] nums, int k) 
    {
        /*
        Get length of nums, and modulo that with k
        Once we have that, populate from the ith value until the end, then from 0 to i-1
        */
        
        int totalLength = nums.Length;
        int moveIndex = totalLength - (k % totalLength);
        int[] cache = new int[totalLength];
        int index = 0;
        
        for(int i = moveIndex; i < totalLength; i++, index++)
        {
            cache[index] = nums[i];
        }
        
        // populate from start to before moveIndex
        for(int i = 0; i < moveIndex; i++, index++)
        {
            cache[index] = nums[i];
        }
        
        // set everything back
        for(int i = 0; i < totalLength; i++)
        {
            nums[i] = cache[i];
        }
    }
    
}