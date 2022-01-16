public class Solution 
{
    public bool ValidWordAbbreviation(string word, string abbr) 
    {
        /*
        we can finish this in max O(n) and less if it errors out
        - since substitions cannot be adjacent, we can parse any number in and see if its still within the word left 
            if not, fail
            if yes, update the index to that position
        if we reach the end without failing + we're not under the length, its true
        */
        
        int wordIndex = 0;
        int digitParser = 0;
        
        for(int i = 0; i < abbr.Length; i++)
        {
            var currentChar = abbr[i];
            if(Char.IsNumber(currentChar))
            {
                // check leading 0 cases
                if(currentChar == '0' && digitParser == 0)
                    return false;
                
                // update the digit parser (since we don't know how many chars are digits in a row)
                digitParser = (digitParser * 10) + (currentChar - '0');
            }
            else
            {
                // add any digits we've parsed
                wordIndex += digitParser;
                // reset the parser
                digitParser = 0;
                
                // ensure that the current char matches the original before adding
                if(wordIndex < word.Length && word[wordIndex] != abbr[i])
                    return false;
                
                // increment it by 1 only if its a normal character
                wordIndex += 1;
                                
                if(wordIndex > word.Length)
                    return false;
            }
        }
        
        // see if there is any leftover digitParser
        if(digitParser != 0)
            wordIndex += digitParser;
                
        // if we are under the count, that fails too
        if(wordIndex != word.Length)
            return false;
        
        
        return true;
    }
}