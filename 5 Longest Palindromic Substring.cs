public class Solution 
{
    public string LongestPalindrome(string s) 
    {
        if(s.Length == 1)
            return s;
        
        // begin at start and end at last
        // find matching start and end
        // when found, check middling chars
        // if a palindrome is found, save and move begin up
        // the length of checks must not be less than current saved palindrome
        
        int begin = 0;
        int end = s.Length - 1;
        string longestPalindrome = "";
        
        // we search for permutations up to the point that the current index + the longestPalindrome length matches the string.
        while(begin + longestPalindrome.Length <= s.Length - 1)
        {
            var iterationResult = FindPalindrome(s, begin, end, longestPalindrome.Length);
            if(iterationResult != null)
                longestPalindrome = iterationResult;
            begin +=1 ;
        }
        
        if(string.IsNullOrEmpty(longestPalindrome))
            return s[0].ToString(); // at minimum, the first char is a palindrome of its own
        else
            return longestPalindrome;
    }
    
    
    public string FindPalindrome(string s, int begin, int end, int minLength)
    {
        for(int i = end; i > begin; i--)
        {
            bool failed = false;
            // if we found matching characters, we must now check all chars in between
            if(s[i] == s[begin])
            {
                int i1 = begin + 1;
                int i2 = i - 1;
                while(i1 <= i2)
                {
                    if(s[i1] != s[i2])
                    {
                        failed = true;
                        break;
                    }
                    i1 += 1;
                    i2 -= 1;
                }
                
                var currentLength = i - begin + 1;
                if(!failed && currentLength > minLength)
                    return s.Substring(begin, currentLength);
            }
                
        }
        return null;
    }
    
}