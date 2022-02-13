public class Solution 
{
    public IList<int> FindAnagrams(string s, string p) 
    {
        if(p.Length > s.Length)
            return new List<int>();
        
        int anagramLength = p.Length;
        int charsToFind = anagramLength;
        List<int> foundIndexes = new List<int>();        
        Dictionary<char, int> toFind = new Dictionary<char, int>();
        
        // add the chars we need + their counts
        foreach(var ch in p)
        {
            if(toFind.ContainsKey(ch))
            {
                toFind[ch] += 1;
            }
            else
            {
                toFind.Add(ch, 1);
            }
        }
        
        // do a single run to pre-load the anagram length in
        for(int i = 0; i < anagramLength; i++)
        {
            var currentChar = s[i];
            if(toFind.ContainsKey(currentChar))
            {
                toFind[currentChar] -= 1;
                if(toFind[currentChar] >= 0)
                    charsToFind -= 1;
            }
        }
        
        // check to see if the first window is valid
        if(charsToFind == 0)
        {
            foundIndexes.Add(0);
        }
           
        // check all other chars 1 and a time
        for(int left = 0, right = anagramLength; right < s.Length; left++, right++)
        {
            // add back the left pointer
            var leftChar = s[left];            
            if(toFind.ContainsKey(leftChar))
            {
                toFind[leftChar] += 1;
                if(toFind[leftChar] >= 1)
                    charsToFind += 1;
            }
            
            // check the new char
            var currentChar = s[right];
            if(toFind.ContainsKey(currentChar))
            {
                toFind[currentChar] -= 1;
                if(toFind[currentChar] >= 0)
                    charsToFind -= 1;
            }
            
            // if we found all the chars we need, we can add this in
            if(charsToFind == 0)
            {
                foundIndexes.Add(left+1);
            }
        }
            
        return foundIndexes;    
    }
    
    
}