public class CombinationIterator 
{
    /*
    Plan, initialize an array equal to combinationLength. This will contain the indexes we're pulling out of characters
    The values would be incremental, aka: length 3, arr = [0,1,2]
    We increment the right most value until it matches combinationLength-1. When reached, increment left of that until it reaches the pos max value
    pos max for each index would be different. It's calculated using: (characters.length - combinationLength) + index location
        AKA if characters.Length = 6 and combinationLength = 4, the pos max would be [2,3,4,5]    
    */
    
    
    int[] posMax;
    int[] currentPos;
    string characters;

    public CombinationIterator(string characters, int combinationLength) 
    {
        this.characters = characters;
        var diff = characters.Length - combinationLength;
        posMax = new int[combinationLength];
        for(int i = 0; i < combinationLength; i++)
        {
            posMax[i] = i + diff;
            //Console.WriteLine($"posMax[i]:{posMax[i]}");
        }
        
        currentPos = new int[combinationLength];
        
        for(int i = 0; i < combinationLength; i++)
        {
            currentPos[i] = i;
            //Console.WriteLine($"currentPos[i]:{currentPos[i]}");
        }
    }
    
    // It's guaranteed that all calls of the function next are valid. no need to handle invalid cases
    public string Next() 
    {
        StringBuilder sb = new StringBuilder();
        foreach(var pos in currentPos)
        {
            sb.Append(characters[pos]);
        }
        // before we return, we must increment the pos
        IncrementPos();
        return sb.ToString();
    }
    
    public bool HasNext() 
    {
        if(currentPos[0] == -1)
            return false;
        else
            return true;
    }
    
    public void IncrementPos()
    {
        // increment right most
        int currentIndex = currentPos.Length - 1;
        
        while(true)
        {
            if(currentPos[currentIndex] < posMax[currentIndex])
            {
                currentPos[currentIndex] += 1;
                //Console.WriteLine($"Incremented {currentIndex}");
                // reset all positions after
                for(int i = currentIndex + 1; i < currentPos.Length; i++)
                {
                    currentPos[i] = currentPos[i-1] + 1;
                }
                break;
            }
            else
            {
                // we've reached the max for this. move left and test it
                currentIndex -= 1;
                if(currentIndex < 0)
                {
                    currentPos[0] = -1;
                    break;
                }
            }
        }
           
    }
}

/**
 * Your CombinationIterator object will be instantiated and called as such:
 * CombinationIterator obj = new CombinationIterator(characters, combinationLength);
 * string param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */