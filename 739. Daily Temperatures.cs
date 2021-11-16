public class Solution 
{
    public int[] DailyTemperatures(int[] temperatures) 
    {
        SortedDictionary<int, List<int>> lookup = new SortedDictionary<int, List<int>>();
        int[] toReturn = new int[temperatures.Length];
        
        for(int i = 0; i < temperatures.Length; i++)
        {
            var currentTemp = temperatures[i];
            List<int> keysToRemove = new List<int>();
            foreach(var kvp in lookup)
            {
                if(kvp.Key < currentTemp)
                {
                    // we found a smaller temp, calculate the diff and save
                    keysToRemove.Add(kvp.Key);
                    var indexesToConsider = kvp.Value;
                    foreach(var index in indexesToConsider)
                    {
                        toReturn[index] = i - index;
                    }
                }
                else
                {
                    // we've reached a higher temperature so nothing else will be smaller since its sorted
                    break;
                }
            }
            
            // if there's any keys we've populated, remove them
            foreach(var toRemove in keysToRemove)
            {
                lookup.Remove(toRemove);
            }
            
            // add in the current temperature
            if(lookup.ContainsKey(currentTemp))
            {
                lookup[currentTemp].Add(i);
            }
            else
            {
                lookup.Add(currentTemp, new List<int>() {i});
            }
        }
        
        return toReturn;
        
    }
}