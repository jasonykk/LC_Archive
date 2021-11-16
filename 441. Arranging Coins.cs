public class Solution 
{
    public int ArrangeCoins(int n) 
    {
        int level = 1;
        while(true)
        {
            if(n < level)
                return level-1; // we shouldn't have added the previous round since we can't make a complete level now
            else
            {
                n -= level;
                level += 1;
            }
        }
        
    }
}