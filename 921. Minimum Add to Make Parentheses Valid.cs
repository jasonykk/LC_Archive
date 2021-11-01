public class Solution 
{
    public int MinAddToMakeValid(string s) 
    {
        int open = 0;
        int close = 0;
        
        foreach(var ch in s)
        {
            if(ch == '(')
                open += 1;
            else if (ch == ')')
            {
                // do we have any opens?
                if(open > 0)
                {
                    open -= 1;
                }
                else
                {
                    close += 1;
                }
            }
        }
        
        return close + open;
    }
}