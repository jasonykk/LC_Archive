public class Solution 
{
    public int MinStartValue(int[] nums) 
    {
        int toAdd = 0;
        var prev = 0;
        
        foreach(var num in nums)
        {
            var current = prev + num;
            if(current < 1)
            {
                toAdd += (1 - current);
                prev = 1;
            }
            else
            {
                prev = current;
            }
        }
        
        // if we never needed any extra values, return 1
        if(toAdd == 0)
            return 1;
        
        return toAdd;
        
    }
}