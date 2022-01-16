public class Solution 
{
    public int MaxDistToClosest(int[] seats) 
    {
        /*
        Parse the array and count distance between 1's.
            if there is only one '1', then we calculate the distance from first/last seat only
            if we find a new distance, we compare with the previous and save that
            distance should be more than 1, as a 1 in 0th index and a 1 in 1st index will have 1-0=1 distance but that means there is no empty spot
        
        */
        
        int maxDistance = Int32.MinValue;
        int currentPersonIndex = -1;
        
        for(int i = 0; i < seats.Length; i++)
        {
            if(seats[i] == 1)
            {
                // we found a person, see if we have distance to calculate
                if(currentPersonIndex != -1)
                {
                    // we now have a distance, see if it's valid
                    int currentDistance = i - currentPersonIndex;
                    // see if we have a new max distance
                    if(currentDistance > 1)
                        maxDistance = Math.Max(maxDistance, currentDistance / 2);                    
                }
                else
                {
                    // this is the first, let's see what the distance is from the first
                    if(i != 0)
                    {
                        maxDistance = i;
                    }
                }
                // update the index
                currentPersonIndex = i;
            }
        }
        
        // a last check in case there answer is at the last seat
        return Math.Max(maxDistance, seats.Length - currentPersonIndex - 1);
    }
}