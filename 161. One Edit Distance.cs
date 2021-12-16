public class Solution 
{
    public bool IsOneEditDistance(string s, string t) 
    {       
        // optimizations
        if(s == t)
            return false;
        
        if(Math.Abs(s.Length - t.Length) > 1)
            return false;
        
        // we do this to ensure that s is the shorter input
        if(s.Length > t.Length)
            return IsOneEditDistance(t, s);
        
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] != t[i])
            {
                // we must now consider if the lengths are the same
                if(s.Length == t.Length)
                {
                    // we check if everything after are equal. if it is, that means that swapping 1 character is sufficient
                    return s.Substring(i+1).Equals(t.Substring(i+1));
                }
                else
                {
                    // see if the strings after matches 
                    return s.Substring(i).Equals(t.Substring(i+1));
                }
            }
        }
        
        // if we find that everything matches, we now see if the difference is only 1
        return t.Length - s.Length == 1;
    }
}