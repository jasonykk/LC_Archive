public class Solution 
{
    public int NumKLenSubstrNoRepeats(string s, int k) 
    {
        /*
        Use 2 pointers up to a length of k. 
            for first setup, move until we find the first valid window
        */
        
        if(s.Length < k)
            return 0;
        
        int left = 0;
        int totalFound = 0;
        HashSet<char> currentChars = new HashSet<char>();
        
        for(int i = 0; i < s.Length; i++)
        {
            if(currentChars.Contains(s[i]))
            {
                while(s[left] != s[i])
                {
                    currentChars.Remove(s[left]);
                    left += 1;
                }
                // left now is at the "old" location of the repeated char. increment it one more time
                currentChars.Remove(s[left]);
                left += 1;
            }
            // add the current
            currentChars.Add(s[i]);
            
            if(currentChars.Count > k)
            {
                // we're over k, remove from left 
                currentChars.Remove(s[left]);
                left += 1;
            }
            
            if(currentChars.Count == k)
            {
                totalFound += 1;
            }
        }
        
        return totalFound;
    }
}