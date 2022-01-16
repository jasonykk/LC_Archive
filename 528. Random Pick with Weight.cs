public class Solution 
{
    Random rand;
    Dictionary<int, double> probabiltyLookup;

    public Solution(int[] w) 
    {
        rand = new Random();
        probabiltyLookup = new Dictionary<int, double>();
        int sum = 0;
        
        // calculate the total sum
        for(int i = 0; i < w.Length; i++)
        {
            sum += w[i];
        }
        
        // calculate the probability for each index and save it
        for(int i = 0; i < w.Length; i++)
        {
            //Console.WriteLine($"w[i]:{w[i]}, sum:{sum}");
            double currentProbability = (double)w[i] / (double)sum;
            probabiltyLookup.Add(i, currentProbability);
            //Console.WriteLine($"Saved i:{i}, prob:{currentProbability}");
        }
    }
    
    public int PickIndex() 
    {
        double currentChance = rand.NextDouble();
        //Console.WriteLine($"currentChance:{currentChance}");
        double chanceUsed = 0.0;
        foreach(var kvp in probabiltyLookup)
        {
            chanceUsed += kvp.Value;
            if(currentChance <= chanceUsed)
                return kvp.Key;
        }
        //Console.WriteLine($"we should not get here");
        return -1;
    }
    
    
    //BruteForceUnlimitedMemory
    /*
    public Solution(int[] w) 
    {
        totalLookup = new List<int>();
        rand = new Random();
        for(int i = 0; i < w.Length; i++)
        {
            int currentValue = w[i];
            // by saving the # of the value for the index, we get the same probability required to return
            for(int j = 0; j < currentValue; j++)
            {
                // we save the index, not the value
                totalLookup.Add(i);
            }
        }
    }
    
    public int PickIndex() 
    {
        int indexToReturn =  rand.Next(totalLookup.Count);
        return totalLookup[indexToReturn];
    }
    */
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(w);
 * int param_1 = obj.PickIndex();
 */