public class Solution 
{
    public int MaximumWealth(int[][] accounts) 
    {
        int maxWealth = Int32.MinValue;
        
        for(int i = 0; i < accounts.Length; i++)
        {
            int currentWealth = 0;
            for(int j = 0; j < accounts[i].Length; j++)
            {
                currentWealth += accounts[i][j];
            }
            maxWealth = Math.Max(maxWealth, currentWealth);
        }
        
        return maxWealth;
    }
}