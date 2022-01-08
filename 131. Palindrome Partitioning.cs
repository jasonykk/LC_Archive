public class Solution 
{
    public IList<IList<string>> Partition(string s) 
    {
        List<IList<string>> toReturn = new List<IList<string>>();
        var currentResult = new List<string>();
        RecursiveCheck(toReturn, currentResult, 0, s);
        return toReturn;
    }
    
    public void RecursiveCheck(List<IList<string>> toReturn, List<string> currentResult, int start, string s)
    {
        if(start >= s.Length)
        {
            List<string> resultToAdd = new List<string>(currentResult);
            toReturn.Add(resultToAdd);
        }
        
        
        for(int i = start; i < s.Length; i++)
        {
            if(IsPalindrome(s, start, i))
            {
                //add current substring
                currentResult.Add(s.Substring(start, i-start+1));
                
                RecursiveCheck(toReturn, currentResult, i+1, s);
                
                // backtrack
                currentResult.RemoveAt(currentResult.Count - 1);
            }
        }
    }
    
    public bool IsPalindrome(string s, int start, int end)
    {
        while(start < end)
        {
            if(s[start] != s[end])
                return false;
            
            start += 1;
            end -= 1;
        }
        
        return true;
    }
    
    
}