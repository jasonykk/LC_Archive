public class Solution 
{
    public int HammingDistance(int x, int y) 
    {
        var xorVal = x ^ y;
        
        string xorString = Convert.ToString(xorVal, 2);
        
        int toReturn = 0;
        
        foreach(var ch in xorString)
        {
            if(ch == '1')
                toReturn += 1;
        }
        
        return toReturn;
    }
}