public class Solution 
{
    public bool CanConstruct(string ransomNote, string magazine) 
    {
        // build array with each lowercase english letter
        // increment as we find in magazine and decrement as we find in ransom
        // return false if count goes negative
        // slower but less memory use
        
        int[] charCount = new int[26];
        
        // build up available chars and their index
        for(int i = 0; i < magazine.Length; i++)
        {
            var currentChar = magazine[i];
            charCount[currentChar - 'a'] += 1;
        }
        
        // iterate through ransomNote until we fail/pass
        foreach(var currentChar in ransomNote)
        {
            charCount[currentChar - 'a'] -= 1;
            if(charCount[currentChar - 'a'] < 0)
                return false;
        }
        
        return true;
        
    }
    
    
    public bool CanConstructV1(string ransomNote, string magazine) 
    {
        // build a dictinary with key=char, value = indexes where they appear
        // if we go through ransomNote and find a char without an index in dictionary, return false
        
        var charLookup = new Dictionary<char, Queue<int>>();
        
        // build up available chars and their index
        for(int i = 0; i < magazine.Length; i++)
        {
            var currentChar = magazine[i];
            Queue<int> indexes;
            if(charLookup.TryGetValue(currentChar, out indexes))
            {
                indexes.Enqueue(i);
            }
            else
            {
                indexes = new Queue<int>();
                indexes.Enqueue(i);
                charLookup.Add(currentChar, indexes);
            }
        }
        
        // iterate through ransomNote until we fail/pass
        foreach(var currentChar in ransomNote)
        {
            Queue<int> indexes;
            if(charLookup.TryGetValue(currentChar, out indexes))
            {
                if(indexes.Count > 0)
                    indexes.Dequeue();
                else
                {
                    // we saw this char but have removed all counts of it
                    return false;
                }
            }
            else
            {
                // we did not find any char in magazine with said value
                return false;
            }
            
        }
        
        return true;
        
    }
    
}