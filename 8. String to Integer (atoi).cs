public class Solution 
{
    public int MyAtoi(string s) 
    {
        // read until we're done with leading whitespaces
        // read until we find '-'/'+' OR a digit 
        // if we find a non-digit, return - as its a failure
        // as we read it, add it to a stringBuilder
        // convert final string to int32 and if fail, return 0
        
        int index = 0;
        StringBuilder sb = new StringBuilder();
        HashSet<char> validIntegers = new HashSet<char>(){'0','1','2','3','4','5','6','7','8','9','.'};
        bool startedProcessing = false;
        bool isNegative = false;
        
        while(index < s.Length)
        {
            char currentChar = s[index];
            if(currentChar == '-' || currentChar == '+')
            {
                // if we see it more than once, this is bad string
                if(startedProcessing)
                    break;
                else
                {
                    startedProcessing = true;
                    if(currentChar == '-')
                        isNegative = true;
                }
            }
            else if(currentChar == ' ')
            {
                // if we found the sign already, return what we found so far
                if(startedProcessing)
                    break;
            }
            else if (validIntegers.Contains(currentChar))
            {
                startedProcessing = true;
                sb.Append(currentChar);
            }
            else
                break;
            
            index += 1;
        }
        
        double toReturn;
        //Console.WriteLine($"sb is{sb.ToString()}");
        if(Double.TryParse(sb.ToString(), out toReturn))
        {
            double finalValue = isNegative ? -1 * toReturn : toReturn;
            if(finalValue > Int32.MaxValue)
                return Int32.MaxValue;
            else if (finalValue < Int32.MinValue)
                return Int32.MinValue;
            return (int)finalValue;
        }
        else 
            return 0;
    }
}