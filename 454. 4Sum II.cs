public class Solution 
{
    Dictionary<int, int> valueLookup;
    
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4) 
    {
        /*
        Add all the numbers from each to the next and save the result into a Dictionary with count
        At the end, the # for 0 is returned
        */
        
        valueLookup = new Dictionary<int, int>();
        AddCurrentArray(nums1);
        AddCurrentArray(nums2);
        AddCurrentArray(nums3);
        AddCurrentArray(nums4);
        
        if(valueLookup.ContainsKey(0))
        {
            return valueLookup[0];
        }
        else
        {
            return 0; 
        }       
    }
    
    public void AddCurrentArray(int[] nums)
    {
        Dictionary<int, int> currentResults = new Dictionary<int, int>();
        if(valueLookup != null && valueLookup.Count > 0)
        {
            foreach(var kvp in valueLookup)
            {
                foreach(var numToAdd in nums)
                {
                    int newVal = kvp.Key + numToAdd;
                    if(currentResults.ContainsKey(newVal))
                    {
                        currentResults[newVal] += kvp.Value;
                    }
                    else
                    {
                        currentResults.Add(newVal, kvp.Value);
                    }
                }
            }
        }
        else
        {
            foreach(var newNum in nums)
            {
                if(currentResults.ContainsKey(newNum))
                {
                    currentResults[newNum] += 1;
                }
                else
                {
                    currentResults.Add(newNum, 1);
                }
            }
        }
        
        // set the values we found
        valueLookup = currentResults;
    }
    
    public void PrintDict()
    {
        Console.WriteLine(valueLookup.Count());
        StringBuilder sb = new StringBuilder();
        foreach(var kvp in valueLookup)
        {
            sb.AppendLine($"{kvp.Key}:{kvp.Value}");
        }
        Console.WriteLine(sb.ToString());
        Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$");        
    }
    
}