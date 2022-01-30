public class Solution 
{
    public IList<int> SequentialDigits(int low, int high) 
    {
        /*
        // we only ever care about sequentially increasing numbers
        // the max a number can go is based on the current length. 
        for example length = 3, max we can go is 789
            length = 4, max we can go is 6789
            so the max "starting" number would be equal to 10-length.        
            
            
        Entirely possible to just pre-compute or use sliding window of 123456789
        */
        int minLength = low.ToString().Length;
        int maxLength = high.ToString().Length;
        int incrementer = GenerateIncrementer(minLength);
        List<int> toReturn = new List<int>();
        
        for(int i = minLength; i <= maxLength; i++)
        {
            // get the starting value
            int currentVal = GenerateStartingValue(i);
            int maxRep = 10 - i;
            int currentRep = 1;
            
            while(currentRep <= maxRep && currentVal <= high)
            {
                // we put the low check inside as we may be looking at smaller than min values first
                if(currentVal >= low)
                {
                    toReturn.Add(currentVal);
                }
                // increment it and try the next larger
                currentVal += incrementer;
                currentRep += 1;
            }  
            
            // we're done lets increment the incrementer used
            incrementer = (incrementer * 10) + 1;
        }
        
        return toReturn;
        
    }
    
    public int GenerateStartingValue(int length)
    {
        int toReturn = 1;
        for(int i = 2; i <= length; i++)
        {
            toReturn = (toReturn * 10) + i;
        }
        return toReturn;
    }
    
    // Helper method to get ones. 
    public int GenerateIncrementer(int length)
    {
        int toReturn = 0;
        
        for(int i = 0; i < length; i++)
        {
            toReturn = (toReturn * 10) + 1;
        }
        
        return toReturn;
    }
    
}