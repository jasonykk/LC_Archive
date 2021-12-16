public class Solution 
{
    public int MaxPower(string s) 
    {
        if(s.Length <= 1)
            return 1;
        
        
        int toReturn = 0;
        int currentCount = 1;
        
        for(int i = 1; i < s.Length; i++)
        {
            if(s[i] == s[i-1])
            {
                currentCount += 1;
            }
            else
            {
                toReturn = Math.Max(currentCount, toReturn);
                currentCount = 1;
            }
        }
        
        // do one final comparison
        return Math.Max(currentCount, toReturn);
    }
}