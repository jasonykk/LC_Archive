public class Solution 
{
    public string RemoveKdigits(string num, int k) 
    {
        if(k >= num.Length)
            return "0";
        
        StringBuilder toReturn = new StringBuilder();
        LinkedList<int> valueCache = new LinkedList<int>();
        int current = num[0] - '0';
        valueCache.AddFirst(current);
        
        for(int i = 1; i < num.Length; i++)
        {
            int newVal = num[i] - '0';
            
            while(k > 0 && valueCache.Count > 0 && newVal < valueCache.Last())
            {
                // the current value is smaller, let's pop
                valueCache.RemoveLast();
                k -= 1;
            }
            
            valueCache.AddLast(newVal);
        }
        
        // its possible that k is not empty, so we won't take the kth last values (recall that the stack should only be increasing in value now)
        while(k > 0)
        {
            valueCache.RemoveLast();
            k -= 1;
        }
        
        // ensure that we don't have leading 0's
        while(valueCache.First.Value == 0 && valueCache.Count > 1)
        {
            valueCache.RemoveFirst();
        }
        
        foreach(var val in valueCache)
        {
            toReturn.Append(val);
        }
        
        return toReturn.ToString();
        
    }
}