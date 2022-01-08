public class Solution 
{
    public int BitwiseComplement(int n) 
    {
        string nBits = Convert.ToString(n, 2);
        var nBitsArr = nBits.ToCharArray();
        
        for(int i = 0; i < nBits.Length; i++)
        {
            if(nBitsArr[i] == '0')
                nBitsArr[i] = '1';
            else
                nBitsArr[i] = '0';
        }
        
        return Convert.ToInt32(new string(nBitsArr), 2);
        
    }
}