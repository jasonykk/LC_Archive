public class RandomizedSet 
{
    public Random rand;
    public Dictionary<int, int> lookup;
    public Dictionary<int, int> keyLookup;
    
    
    public RandomizedSet() 
    {
        rand = new Random();
        lookup = new Dictionary<int, int>();
        keyLookup = new Dictionary<int, int>();
    }
    
    public bool Insert(int val) 
    {
        int currentKey = lookup.Count;
        
        if(lookup.TryAdd(val, currentKey))
        {
            keyLookup.Add(currentKey, val);
            return true;
        }
        else
            return false;
    }
    
    public bool Remove(int val) 
    {
        if(lookup.ContainsKey(val))
        {
            var associatedKey = lookup[val];
            // swap the last value with this
            var lastValue = keyLookup[keyLookup.Count-1];
            lookup[lastValue] = associatedKey;
            keyLookup[associatedKey] = lastValue;
            lookup.Remove(val);
            keyLookup.Remove(keyLookup.Count-1);
            return true;
        }
        else
            return false;
    }
    
    public int GetRandom() 
    {
        var randomKey = rand.Next(lookup.Count);
        return keyLookup[randomKey];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */