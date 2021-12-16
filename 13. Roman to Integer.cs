public class Solution 
{
    public int RomanToInt(string s) 
    {
        Dictionary<char, int> romanLookup = new Dictionary<char, int>();
        Dictionary<char, int> valueLookup = new Dictionary<char, int>();
        romanLookup.Add('I', 0); valueLookup.Add('I', 1);
        romanLookup.Add('V', 1); valueLookup.Add('V', 5);
        romanLookup.Add('X', 2); valueLookup.Add('X', 10);
        romanLookup.Add('L', 3); valueLookup.Add('L', 50);
        romanLookup.Add('C', 4); valueLookup.Add('C', 100);
        romanLookup.Add('D', 5); valueLookup.Add('D', 500);
        romanLookup.Add('M', 6); valueLookup.Add('M', 1000);
        
        int toReturn = 0;
        int previousRomanIndex = Int32.MaxValue;
        
        for(int i = 0; i < s.Length; i++)
        {
            var currentChar = s[i];
            var currentRomanIndex = romanLookup[currentChar];
            bool processed = false;
            
            if(currentRomanIndex == 0)
            {
                // this may be a special case: I
                // see if its V or X
                if(i+1 < s.Length)
                {
                    if(romanLookup[s[i+1]] == 1)
                    {
                        toReturn += 4;
                        i += 1;
                        processed = true;
                    }
                    else if(romanLookup[s[i+1]] == 2)
                    {
                        toReturn += 9;
                        i += 1;
                        processed = true;
                    }
                }
            }
            else if(currentRomanIndex == 2)
            {
                // this may be a special case: X
                // see if its L or C
                if(i+1 < s.Length)
                {
                    if(romanLookup[s[i+1]] == 3)
                    {
                        toReturn += 40;
                        i += 1;
                        processed = true;
                    }
                    else if(romanLookup[s[i+1]] == 4)
                    {
                        toReturn += 90;
                        i += 1;
                        processed = true;
                    }
                }
            }
            else if(currentRomanIndex == 4)
            {
                // this may be a special case: C
                // see if its D or M
                if(i+1 < s.Length)
                {
                    if(romanLookup[s[i+1]] == 5)
                    {
                        toReturn += 400;
                        i += 1;
                        processed = true;
                    }
                    else if(romanLookup[s[i+1]] == 6)
                    {
                        toReturn += 900;
                        i += 1;
                        processed = true;
                    }
                }
            }
                        
            if(!processed)
            {
                toReturn += valueLookup[currentChar];
            }
                
        }
        
        return toReturn;
        
    }
}