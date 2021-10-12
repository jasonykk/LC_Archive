public class Solution 
{
    public int LengthOfLongestSubstring(string s) 
    {
        // optimizations
        if(String.IsNullOrEmpty(s))
            return 0;
        
        // at minimum we always return 1 char length
        int toReturn = 1;
        
        Dictionary<char, int> charToLastLocationMap = new Dictionary<char, int>();
        
        for (int start = 0, end = 0; end < s.Length; end++)
        {
            var currentChar = s[end];
            
            // if the current char already exists, we need to start again at the next index (as there's a repeat)
            if (charToLastLocationMap.Keys.Contains(currentChar))
            {
                var lastIndexOfCurrentChar = charToLastLocationMap[currentChar];
                start = Math.Max(start, lastIndexOfCurrentChar + 1);
            }
            
            // update loc of current char in map
            charToLastLocationMap[currentChar] = end;      
            
            // check to see if we found a longer non-repeat substring
            toReturn = Math.Max(toReturn, end - start + 1);
        }
        
        return toReturn;
    }
    
}