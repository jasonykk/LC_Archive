public class Solution 
{
    public IList<IList<string>> GroupStrings(string[] strings) 
    {
        /*
        It appears there are two main things
            - length of the string : Dict<length, Dict>
            - "distance" of each char : Dict<distance, List<string>>            
        At the end just take concat all the lists and return them
        
        BUT, we since we're already calcualting the distances and appending as string, we can immediately use it as the dict key
        */
        
        List<IList<string>> toReturn = new List<IList<string>>();
        var distanceLookup = new Dictionary<string, List<string>>();
        
        foreach(string input in strings)
        {
            // find the distances between each char 
            StringBuilder sb = new StringBuilder();

            for(int i = 1; i < input.Length; i++)
            {
                // we always add 26 as its possible for the 2nd char to be 'smaller' than the 1st char after moving by adding it, 
                // we should constantly have a proper value (even with first is "smaller")
                sb.Append($"{Math.Abs(input[i-1] - input[i] + 26) % 26},");
            }

            var currentKey = sb.ToString();
            if(distanceLookup.ContainsKey(currentKey))
            {
                distanceLookup[currentKey].Add(input);
            }
            else
            {
                var relatedStrings = new List<string>();
                relatedStrings.Add(input);
                distanceLookup.Add(currentKey, relatedStrings);
            }
        }
        
        // now that we've set everything up, concat all results
        foreach(var resultsPerDistance in distanceLookup)
        {
            toReturn.Add(resultsPerDistance.Value);
        }
        
        return toReturn;        
    }
    
    
    /*
    public IList<IList<string>> GroupStringsLengthAndDistance(string[] strings) 
    {
        // method using length as well but its longer
        List<IList<string>> toReturn = new List<IList<string>>();
        var lengthAndDistanceLookup = new Dictionary<int, Dictionary<string, List<string>>>();
        
        foreach(string input in strings)
        {
            // find the length
            int currentLength = input.Length;
            if(currentLength == 1)
            {
                // if the length is 1, we don't need to find any distance
                SaveResult(currentLength, "0", lengthAndDistanceLookup, input);
            }
            else
            {
                // find the distances between each char 
                StringBuilder sb = new StringBuilder();

                for(int i = 1; i < input.Length; i++)
                {
                    // we always add 26 as its possible for the 2nd char to be 'smaller' than the 1st char after moving by adding it, 
                    // we should constantly have a proper value (even with first is "smaller")
                    sb.Append($"{Math.Abs(input[i-1] - input[i] + 26) % 26},");
                }
                
                SaveResult(currentLength, sb.ToString(), lengthAndDistanceLookup, input);
            }
        }
        
        // now that we've set everything up, concat all results
        foreach(var kvp in lengthAndDistanceLookup)
        {
            foreach(var resultsPerLength in kvp.Value)
            {
                toReturn.Add(resultsPerLength.Value);
            }
        }
        
        return toReturn;        
    }
    
    public void SaveResult(int length, string distances, Dictionary<int, Dictionary<string, List<string>>> lengthAndDistanceLookup, string input)
    {
        if(lengthAndDistanceLookup.ContainsKey(length))
        {
            if(lengthAndDistanceLookup[length].ContainsKey(distances))
            {
                lengthAndDistanceLookup[length][distances].Add(input);
            }
            else
            {
                lengthAndDistanceLookup[length].Add(distances, new List<string>{input});
            }
        }
        else
        {
            var relatedStrings = new Dictionary<string, List<string>>();
            relatedStrings.Add(distances, new List<string>{input});
            lengthAndDistanceLookup.Add(length, relatedStrings);
        }
    }
    */
    
}