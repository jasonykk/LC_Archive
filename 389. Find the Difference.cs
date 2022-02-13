public class Solution 
{
    public char FindTheDifference(string s, string t) 
    {
        // use a Dict to build up char + count. deduct from t and the remainder is the added char
        Dictionary<char, int> valueLookup = new Dictionary<char, int>();
        
        // populate initial counts
        foreach(var ch in s)
        {
            if(valueLookup.ContainsKey(ch))
            {
                valueLookup[ch] += 1;
            }
            else
            {
                valueLookup.Add(ch, 1);
            }
        }
        
        // deduct from valueLookup
        foreach(var ch in t)
        {
            if(valueLookup.TryGetValue(ch, out int count))
            {
                count -= 1;
                if(count < 0)
                    return ch;
                else
                    valueLookup[ch] = count;
            }
            else
            {
                return ch;
            }
        }
        
        throw new Exception("should not get here");
    }
}