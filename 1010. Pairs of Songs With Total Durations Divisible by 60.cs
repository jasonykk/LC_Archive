public class Solution 
{
    public int NumPairsDivisibleBy60(int[] time) 
    {
        int toReturn = 0;
        int[] moduloCounts = new int[60];
        
        for(int i = 0; i < time.Length; i++)        
        {
            int moduloVal = time[i] % 60;
            
            // add first since the "first" time a value is found, there is no pairing yet
            if(moduloVal == 0)
            {
                toReturn += moduloCounts[0];
            }
            else
            {
                // add the paired modulo value instead (1-59), (2-58) . . .
                toReturn += moduloCounts[60 - moduloVal];
            }
            
            //increment the count now so if any is seen after, we get the right value
            moduloCounts[moduloVal] += 1;
        }
                
        return toReturn;
        
    }
    
}