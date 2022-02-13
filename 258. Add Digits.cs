public class Solution 
{
    public int AddDigits(int num) 
    {
        while(num > 9)
        {
            num = GetCurrentValue(num);
        }
        return num;
    }
    
    public int GetCurrentValue(int num)
    {
        int toReturn = 0;
        
        while(num % 10 != 0 || num / 10 >= 1)
        {
            toReturn += num % 10;
            num /= 10;
        }
        
        return toReturn;
    }
    
}