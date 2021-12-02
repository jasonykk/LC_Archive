public class Solution 
{
    public int[] ProductExceptSelf(int[] nums) 
    {
        /*
        Brute force: Time O(2n) == O(n)
        Multiply all the values to get a final product
        Iterate a 2nd time and at each value, divide the final product with the current number.
        
        Solution:
        Since we can't divide, and still need O(n), we use two arrays left/right, to contain the product as we go
        Then multiplying the same index for each, should give us the appropriate value
        
        */
        
        int[] left = new int[nums.Length];
        int[] right = new int[nums.Length];
        int[] toReturn = new int[nums.Length];
        
        for(int l = 0, r = nums.Length-1; r >= 0; l++, r--)
        {
            if(l == 0)
            {
                // since there is nothing left of the first index, default to 1
                left[l] = 1;
                // since there is nothing right of the last index, default to 1
                right[r] = 1;
            }
            else
            {
                // any other index, we multiply the previous value to the previous product (recall that at index left[l] we get the product of everything up to but NOT including l)
                left[l] = left[l-1] * nums[l-1];
                right[r] = right[r+1] * nums[r+1];
            }
        }
        
        for(int i = 0; i < nums.Length; i++)
        {
            toReturn[i] = left[i] * right[i];
        }
        
        
        return toReturn;
    }
}
