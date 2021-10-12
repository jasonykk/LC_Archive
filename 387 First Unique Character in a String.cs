public class Solution 
{
    public int FirstUniqChar(string s) 
    {
        // one array to keep track of the frequency
        // another array to keep track of the first location of each
        // return the earliest index from the 2nd array given freq == 1
        
        int[] freq = new int[26];
        int[] firstIndex = new int[26];
        int toReturn = Int32.MaxValue;
        
        for(int i = 0; i < s.Length; i++)
        {
            var ch = s[i];
            var currentChar = ch - 'a';
            freq[currentChar] += 1;
            if(freq[currentChar] == 1)
                firstIndex[currentChar] = i;         
        }
        
        for(int i = 0; i < freq.Count(); i++)
        {
            if(freq[i] == 1)
                toReturn = Math.Min(toReturn, firstIndex[i]);
        }
        
        if(toReturn == Int32.MaxValue)
            return -1;
        
        return toReturn;       
        
    }
    
    
    public int FirstUniqCharV1(string s) 
    {
        // keep a dictionary for each char with the value being index where the char is located
        // if a char is found again, set to a marker index (-1) so we can avoid this later
        // go through results and return the earliest index (only lists that have value <> -1 as they are non-repeated)
        
        Dictionary<char, int> lookup = new Dictionary<char, int>();
        int toReturn = Int32.MaxValue;
        
        for(int i = 0; i < s.Length; i++)
        {
            var ch = s[i];
            
            if(lookup.ContainsKey(ch))
                lookup[ch] = -1;
            else
                lookup[ch] = i;                
        }
        
        foreach(var kvp in lookup)
        {
            if(kvp.Value != -1)
                toReturn = Math.Min(toReturn, kvp.Value);
        }
        
        if(toReturn == Int32.MaxValue)
            return -1;
        
        return toReturn;       
        
    }
    
}