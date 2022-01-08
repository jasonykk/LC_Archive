public class Solution 
{
    public bool ValidPalindrome(string s) 
    {
        /*
        Seems like a two pointer question?
        have a start/end pointer. they should match moving towards the center
        if there is no match, check if start +1 = end OR end-1 = start
            if yes, we can proceed. we should mark that we've made 1 removal
        if we remove more than 1, we failed
        */
        
        int start = 0;
        int end = s.Length - 1;
        
        while(start < end)
        {
            if(s[start] == s[end])
            {
                start += 1;
                end -= 1;
            }
            else
            {
                return ValidPalindrome(s, start+1, end) || ValidPalindrome(s, start, end-1);
            }
        }
        
        //if we get here, it is a valid palindrome
        return true;
        
    }
    
    
    public bool ValidPalindrome(string s, int start, int end) 
    {
        while(start < end)
        {
            if(s[start] == s[end])
            {
                start += 1;
                end -= 1;
            }
            else
                return false;
        }
        
        return true;
    }
}