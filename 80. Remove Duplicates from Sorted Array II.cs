public class Solution 
{
    public int RemoveDuplicates(int[] nums) 
    {
        if(nums.Length <= 1)
            return 1;
        
        int left = 0;
        int count = 1;
        
        for(int i = 1; i < nums.Length; i++)
        {
            if(nums[i] == nums[left])
            {
                //see if we're over the count
                if(count == 2)
                {
                    // we keep moving i until the number isn't the same anymore
                    while(nums[i] == nums[left])
                    {
                        i += 1;
                        // if we reach the end before we're done finding another, we can return directly
                        if(i >= nums.Length)
                        {
                            //Console.WriteLine("early exit");
                            return left+1;
                        }
                    }
                    
                    // we found a new number, reset the count               
                    count = 1;
                }
                else
                {
                    // we can safely increment
                    count += 1;
                }
            }
            else
            {
                // we found a new number!
                //reset the count
                count = 1;
            }
            
            left += 1;
            nums[left] = nums[i];
        }
        
        // left is 0th indexed so we add 1
        return left+1;
    }
}