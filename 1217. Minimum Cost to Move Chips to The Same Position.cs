public class Solution 
{
    public int MinCostToMoveChips(int[] position) 
    {
        int evens = 0;
        int odds = 0;
        
        for(int i = 0; i < position.Length; i++)
        {
            if(position[i] % 2 == 0)
            {
                evens += 1;
            }
            else
            {
                odds += 1;
            }
        }
        
        if(evens == 0 || odds == 0)
            return 0;
        else
        {
            return Math.Min(evens, odds);
        }
        
    }
}