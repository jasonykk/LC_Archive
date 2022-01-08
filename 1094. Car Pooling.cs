public class Solution 
{
    public bool CarPooling(int[][] trips, int capacity) 
    {
        var customComparer = new CustomComparer();
        // sort the array first based on the starting pos (as we pick them up) and if equal, by the drop off
        Array.Sort(trips, customComparer);
        
        int currentCapacity = capacity;
        SortedDictionary<int, int> destinations = new SortedDictionary<int, int>();
        
        foreach(var trip in trips)
        {
            //do we have anyone to drop off (we have people + the prev destination was before or equal to the "start")
            if(currentCapacity != capacity)
            {
                List<int> toRemove = new List<int>();
                foreach(var destinationKVP in destinations)
                {
                    if(destinationKVP.Key <= trip[1])
                    {
                        toRemove.Add(destinationKVP.Key);
                        currentCapacity += destinationKVP.Value;
                    }
                    else
                        break;
                }
                
                if(toRemove.Count > 0)
                {
                    foreach(var keyToRemove in toRemove)
                    {
                        destinations.Remove(keyToRemove);
                    }
                }
            }
            
            // add anyone new
            currentCapacity -= trip[0];
            
            if(currentCapacity < 0)
                return false;
            else
            {
                // update destinations
                if(destinations.ContainsKey(trip[2]))
                {
                    destinations[trip[2]] += trip[0];
                }
                else
                {
                    destinations.Add(trip[2], trip[0]);
                }
            }
        }
        
        
        return true;
    }
    
    public void PrintArray(int[][] arr)
    {
        StringBuilder sb = new StringBuilder();
        foreach(var input in arr)
        {
            sb.Append($"[{input[0]},{input[1]},{input[2]}],");
        }
        Console.WriteLine(sb.ToString());
    }
}

public class CustomComparer: IComparer<int[]>
{
    public int Compare(int[] x, int[] y)
    {
        int startingPos = x[1].CompareTo(y[1]);
        
        if(startingPos != 0)
        {
            return startingPos;
        }
        else
        {
            return x[2].CompareTo(y[2]);
        }
    }
    
}