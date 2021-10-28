public class Solution 
{
    public string ReverseWords(string s) 
    {
        // trim the string to remove extra spaces first
        // split the string based on single space
        // rebuild the string from the back to front, skipping any empty space ones
        
        s = s.Trim();
        var words = s.Split(' ');
        StringBuilder sb = new StringBuilder();
        
        for(int i = words.Length - 1; i >= 0 ; i--)
        {
            if(!string.IsNullOrWhiteSpace(words[i]))
               sb.Append($"{words[i]} ");
        }
               
        // now at the end we have 1 extra space, remove it and return
        var finalString = sb.ToString();
        return finalString.Substring(0, finalString.Length - 1);
        
    }
}