public class Solution 
{
    public int MajorityElement(int[] nums) 
    {
        /*
        Option:
        1) Dictinary, keep track of counts and return max count c space (unique nums), n + c time
        2) Sort the array, keep count as we go and retain max (Onlogn + n) time, 1 space
        */
        
        Array.Sort(nums);
        
        int maxCount = 0;
        int maxNum = nums[0];
        int currentCount = 0;
        int currentNum = nums[0];
        
        foreach(var num in nums)
        {
            if(currentNum == num)
            {
                currentCount += 1;
            }
            else
            {
                // its a new number, reset the count
                currentCount = 1;
                currentNum = num;
            }
            
            if(maxCount < currentCount)
            {
                // update
                maxCount = currentCount;
                maxNum = num;
            }
        }
        
        return maxNum;
    }
}