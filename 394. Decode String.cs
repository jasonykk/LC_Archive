public class Solution 
{
    public string DecodeString(string s) 
    {
        var toReturn = ProcessBrackets(s, 1);
        return toReturn.ToString();
    }
    
    public string ProcessBrackets(string s, int repetitions)
    {
        StringBuilder sb = new StringBuilder();
        
        for(int i = 0; i < s.Length; i++)
        {
            // if its a digit, we must recurse process the block
            if(System.Char.IsDigit(s[i]))
            {
                string digitString = "";
                
                //process until we're done with digits
                while(System.Char.IsDigit(s[i]))
                {
                    digitString += s[i];
                    i += 1;
                }
                
                int newReps = Convert.ToInt32(digitString);
                
                //we now need to find the block to repeat
                int brackets = 1;
                // increment since the first non-digit is the '['
                i += 1;
                
                StringBuilder newString = new StringBuilder();
                while(s[i] != ']' || brackets > 0)
                {
                    if(s[i] == ']')
                    {
                        brackets -= 1;
                        if(brackets == 0)
                            break;
                    }
                    else if(s[i] == '[')
                    {
                        brackets += 1;
                    }
                    // add the character in (including any internal '[')
                    newString.Append(s[i]);
                    i += 1;
                }
                
                sb.Append(ProcessBrackets(newString.ToString(), newReps));                
            }
            else
            {
                sb.Append(s[i]);
            }
        }
        
        var singleFormedString = sb.ToString();
        for(int i = 1; i < repetitions; i++)
        {
            sb.Append(singleFormedString);
        }
        
        return sb.ToString();
    }
}