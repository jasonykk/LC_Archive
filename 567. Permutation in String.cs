public class Solution 
{
    public bool CheckInclusion(string s1, string s2) 
    {
        // optimization
        if(s1.Length > s2.Length)
            return false;
        
        // build up counts for s1
        Dictionary<char, int> s1Counts = new Dictionary<char, int>();
        foreach(var ch in s1)
        {
            if(s1Counts.ContainsKey(ch))
            {
                s1Counts[ch] += 1;
            }
            else
            {
                s1Counts.Add(ch, 1);
            }
        }
        
        // we now have all the counts for s1. go through s2 using a moving window to see if we have what we need
        Dictionary<char, int> s2Counts = new Dictionary<char, int>();
        
        // load the first window
        for(int i = 0; i < s1.Length; i++)
        {
            var ch = s2[i];
            if(s2Counts.ContainsKey(ch))
            {
                s2Counts[ch] += 1;
            }
            else
            {
                s2Counts.Add(ch, 1);
            }
        }
        
        for(int i = s1.Length, left = 0; i < s2.Length; i++, left++)
        {
            bool currentCheck = VerifyCounts(s1Counts, s2Counts);
            if(currentCheck)
            {
                return true;
            }
            else
            {
                // see if we can move the window
                var ch = s2[left];
                s2Counts[ch] -= 1;
                if(s2Counts[ch] == 0)
                {
                    s2Counts.Remove(s2[left]);
                }
                
                // add new char (update ch)
                ch = s2[i];
                if(s2Counts.ContainsKey(ch))
                {
                    s2Counts[ch] += 1;
                }
                else
                {
                    s2Counts.Add(ch, 1);
                }
            }
            
        }
        
        // last round to ensure the counts are fine
        return VerifyCounts(s1Counts, s2Counts);
        
    }
    
    public bool VerifyCounts(Dictionary<char, int> s1Counts, Dictionary<char, int> s2Counts)
    {
        foreach(var kvp in s2Counts)
        {
            if(s1Counts.TryGetValue(kvp.Key, out var associatedCount))
            {
                if(associatedCount != kvp.Value)
                    return false;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
    
}