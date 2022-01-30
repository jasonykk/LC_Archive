public class Solution 
{
    public bool DetectCapitalUse(string word) 
    {
        HashSet<char> uppercaseLetters = new HashSet<char>{'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
        
        int upperCount = 0;
        int lowerCount = 0;
        bool hasUpperFirstChar = false;
        
        foreach(var ch in word)
        {
            if(uppercaseLetters.Contains(ch))
            {
                if(!hasUpperFirstChar)
                {
                    if(upperCount == 0 && lowerCount == 0)
                    {
                        hasUpperFirstChar = true;
                    }
                }
                else if(lowerCount > 1)
                {
                    // if its not the first char AND we have found an upper case letter, this has broken the mold
                    return false;
                }
                upperCount += 1;
            }
            else
            {
                lowerCount += 1;
            }
        }
        
        
        if(lowerCount == word.Length)
            return true;
        else if(upperCount == word.Length)
            return true;
        else if(hasUpperFirstChar && lowerCount == word.Length-1 && upperCount == 1)
            return true;
        else 
            return false;
        
    }
}