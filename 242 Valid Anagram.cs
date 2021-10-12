public class Solution 
{
    public bool IsAnagram(string s, string t) 
    {
        // we can exit early if the lengths are not the same
        // loop once and increment/decrement based on which string it is
        // check the array for any counts not 0
        
        if(s.Length != t.Length)
            return false;
        
        int[] index = new int[26];
        
        for(int i = 0; i < s.Length; i++)
        {
            index[s[i] - 'a'] += 1;
            index[t[i] - 'a'] -= 1;
        }
        
        // check the counts to see if they are all 0
        foreach(var count in index)
        {
            if(count != 0)
                return false;
        }
        
        return true;
        
    }
    
    
    public bool IsAnagramV1(string s, string t) 
    {
        // build an array with the count of chars for s
        // decrement the count based on chars found at t
        // if the array has count > 1 on any index, return false as its not an anagram
        
        int[] index = new int[26];
        
        foreach(var ch in s)
        {
            index[ch - 'a'] += 1;
        }
        
        foreach(var ch in t)
        {
            var current = ch - 'a';
            index[current] -= 1;
            if(index[current] < 0)
                return false;
        }
        
        // we cannot be sure yet if this is an anagram without re-checking the entire array
        foreach(var count in index)
        {
            if(count != 0)
                return false;
        }
        
        return true;
        
    }
}