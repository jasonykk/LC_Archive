public class Solution 
{
    public int FindComplement(int num) 
    {
        var numAsBits = Convert.ToString(num, 2).ToCharArray();
        
        for(int i = 0; i < numAsBits.Length; i++)
        {
            if(numAsBits[i] == '1')
                numAsBits[i] = '0';
            else
                numAsBits[i] = '1';
        }
        
        return Convert.ToInt32(new string(numAsBits), 2);
    }
}