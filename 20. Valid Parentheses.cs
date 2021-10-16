public class Solution 
{
    public bool IsValid(string s) 
    {
        // create a stack for matching purposes (last in, last out)
        // iterate through, and add chars
        // if we find an opening, add to stack
        // if we find a closing, see if it matches the previously added item
        // fail if not and if it is, pop it.
        // when at the end of the string, see if there's anything left in the stack and fail
        
        Stack<char> lookup = new Stack<char>();
        
        for(int i = 0; i < s.Length; i++)
        {
            var currentChar = s[i];
            
            // check if opening
            if(currentChar == '(' || currentChar == '{' || currentChar == '[')
                lookup.Push(currentChar);
            else 
            {
                if(lookup.Count() == 0)
                {
                    // we found a closer that has no opening
                    return false;
                }
                else
                {
                    // we know its a closing paren beacuse the valid chars are parens only
                    var lastParen = lookup.Peek();
                    if((currentChar == ')' && lastParen == '(') 
                       || (currentChar == '}' && lastParen == '{') 
                       || (currentChar == ']' && lastParen == '[') 
                      )
                    {
                        lookup.Pop();
                    }
                    else
                        return false;
                }
            }
            
        }
        
        // on ending, if there's anything left means we have a hanging opener
        if(lookup.Count() > 0)
            return false;
        else
            return true;
        
        
        
    }
}