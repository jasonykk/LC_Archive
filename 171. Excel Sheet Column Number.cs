public class Solution 
{
    public int TitleToNumber(string columnTitle) 
    {
        int colNum = 0;
        
        foreach(var ch in columnTitle)
        {
            // we're moving up 1 char so we've done at least 26
            colNum *= 26;
            // add the current char. we add one since we are not 0th based. A is 1 rather than 0.
            colNum += (ch - 'A') + 1;
        }
        
        return colNum;
        
    }
}