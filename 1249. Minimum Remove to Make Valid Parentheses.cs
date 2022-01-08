public class Solution 
{
    public string MinRemoveToMakeValid(string s) 
    {
        return MinRemoveToMakeValidReverseMethod(s);
    }
    
    public string MinRemoveToMakeValidStack(string s) 
    {
        Stack<int> openIndex = new Stack<int>();
        StringBuilder sb = new StringBuilder();
        HashSet<int> toSkip = new HashSet<int>();
        
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] == '(')
            {
                openIndex.Push(i);
            }
            else if(s[i] == ')')
            {
                if(openIndex.Count == 0)
                {
                    //there is no open to pair with
                    toSkip.Add(i);
                }
                else
                {
                    openIndex.Pop();
                }
            }
        }
        
        // add all unmatched open brackets
        while(openIndex.Count > 0)
        {
            toSkip.Add(openIndex.Pop());
        }
        
        for(int i = 0; i < s.Length; i++)
        {
            if(!toSkip.Contains(i))
                sb.Append(s[i]);
        }
        
        return sb.ToString();
    }
    
    public string MinRemoveToMakeValidReverseMethod(string s) 
    {
        Console.WriteLine(s);
        var firstPass = RemoveInvalidClosing(s, '(', ')');
        Console.WriteLine(firstPass);
        var secondPass = RemoveInvalidClosing(ReverseString(firstPass), ')', '(');
        Console.WriteLine(secondPass);
        return ReverseString(secondPass);
    }
    
    public string ReverseString(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
    
    public string RemoveInvalidClosing(string s, char open, char close)
    {
        StringBuilder sb = new StringBuilder();
        int bracketCount = 0;
        
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] == open)
            {
                bracketCount += 1;
            }
            else if(s[i] == close)
            {
                if(bracketCount == 0)
                {
                    // since there is no open bracket to pair with, we skip this
                    continue;
                }
                else
                {
                    bracketCount -= 1;
                }
            }
            
            // if we didn't skip due to an invalid pair, we append the char
            sb.Append(s[i]);
        }
        
        return sb.ToString();
    }
    
    public string MinRemoveToMakeValidManualCheckWithQueues(string s) 
    {
        int totalLength = s.Length;
        int left = 0;       
        int right = s.Length - 1;
        char[] fixedString = s.ToCharArray();
        
        Queue<int> openers = new Queue<int>();
        Queue<int> closers = new Queue<int>();
        
        for(int i = 0; i < totalLength; i++)
        {
            if(s[i] == '(')
            {
                openers.Enqueue(i);
            }
            else if(s[i] == ')')
            {
                closers.Enqueue(i);
            }
        }
        
        // we now have all the positions we care about
        if(openers.Count == 0 && closers.Count == 0)
        {
            // we have no () characters
            return s;
        }
        else if(openers.Count == 0)
        {
            // if there are only closers, remove all of them
            return s.Replace(")", "");
        }
        else if(closers.Count == 0)
        {
            // if there are only openers, remove all of them
            return s.Replace("(", "");
        }
        else
        {
            while(openers.Count > 0 && closers.Count > 0)
            {
                //Console.WriteLine($"openers:{openers.Count}, closers:{closers.Count}");
                // openers must be before closures
                while(openers.Count > 0 && closers.Count > 0
                      && openers.Peek() < closers.Peek())
                {
                    //we can pop these as that's valid
                    openers.Dequeue();
                    closers.Dequeue();
                }

                //Console.WriteLine($"OP1: openers:{openers.Count}, closers:{closers.Count}");
                
                // check if we have illegal closers
                while(closers.Count > 0 && openers.Count > 0
                     && closers.Peek() < openers.Peek())
                {
                    int illegalCloser = closers.Dequeue();
                    fixedString[illegalCloser] = 'X';
                }
                
                //Console.WriteLine($"OP2: openers:{openers.Count}, closers:{closers.Count}");
                
                if(closers.Count == 0)
                {
                    // all remainder openers are illegal
                    while(openers.Count > 0)
                    {
                        var idx = openers.Dequeue();
                        fixedString[idx] = 'X';
                    }
                }
                else
                {
                    // check if we have illegal openers (come after the last closer we have)
                    while(openers.Count > 0 && openers.Peek() > closers.Peek())
                    {
                        int illegalCloser = openers.Dequeue();
                        fixedString[illegalCloser] = 'X';
                    }
                    
                    if(openers.Count == 0)
                    {
                        // all remainder openers are illegal
                        while(closers.Count > 0)
                        {
                            var idx = closers.Dequeue();
                            fixedString[idx] = 'X';
                        }
                    }
                }

            }
        }
        
        // we should be able to cast it to a string now
        StringBuilder sb = new StringBuilder();
        foreach(var ch in fixedString)
        {
            if(ch != 'X')
                sb.Append(ch);
        }
        
        return sb.ToString();
    }
    
}