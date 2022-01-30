public class Solution 
{
    public int MinEatingSpeed(int[] piles, int h) 
    {
        /*
        binary search it!
        */
        
        int left = 1;
        int right = Int32.MinValue;
        
        foreach(var pile in piles)
        {
            // find and set the largest pile
            right = Math.Max(right, pile);
        }
        
        // binary search based on k(or speed!)
        while(left < right)
        {
            int currentSpeed = (left + (right-left) / 2);
            int hoursAtCurrentSpeed = 0;
            
            foreach(var pile in piles)
            {
                // use the ceiling as even if there's 1 banana left, we must take the next hour on it
                hoursAtCurrentSpeed += (int)Math.Ceiling((double)pile/ currentSpeed);
            }
            
            if(hoursAtCurrentSpeed <= h)
            {
                right = currentSpeed;
            }
            else
            {
                left = currentSpeed + 1;
            }
        }
                
        return left;
        
    }
}