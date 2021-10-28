public class Solution 
{
    public int FindMin(int[] nums) 
    {
        if(nums.Length == 1)
            return nums[0];
        
        int left = 0;
        int right = nums.Length - 1;
        
        while(left < right)
        {
            int midIndex = (left + right) / 2;
            
            //Console.WriteLine($"left:{left},   right:{right},   midIndex:{midIndex}");
            
            // if equal, lets try reducing the "scope" of the range by 1 (worse case we scan everything but with dupes there is no other option)
            if(nums[midIndex] == nums[right])
            {
                right -= 1;
            }
            else if(nums[midIndex] > nums[right])
                left = midIndex + 1;
            else
                right = midIndex;
        }
        
        return nums[left];
    }
    
    
}