public class WordDictionary 
{
    /*
    Utilize a trie data structure to keep the connections
    
    */

    Dictionary<int, HashSet<string>> lookup;
    
    public WordDictionary() 
    {
        lookup = new Dictionary<int, HashSet<string>>();
    }
    
    public void AddWord(string word) 
    {
        int currentLength = word.Length;
        if (!lookup.ContainsKey(currentLength)) 
        {
            lookup.Add(currentLength, new HashSet<string>());
        }
        lookup[currentLength].Add(word);
    }
    
    public bool Search(string word) 
    {        
        int currentLength = word.Length;
        
        if(lookup.TryGetValue(currentLength, out var relatedStrings))
        {
            foreach(var savedString in relatedStrings)
            {
                int i = 0;
                // we increment ONLY if everything matches
                while(i < currentLength && (word[i] == '.' || word[i] == savedString[i]))
                {
                    i += 1;
                }
                        
                // if the count matches, we found a match
                if(i == currentLength)
                    return true;
            }
        }
        
        return false;
    }
}

                       

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */