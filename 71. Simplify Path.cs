public class Solution 
{
    public string SimplifyPath(string path) 
    {
		/*
		first split the string by /
		then parse each of it separately!
		if empty or .  we can ignore
		if .. we must remove the last updated thing (only if there is something
		*/
        var splitInput = path.Split('/');
        List<string> toJoin = new List<string>();
        
        foreach(var input in splitInput)
        {
            ParsePathPart(input, toJoin);
        }
        
        string simplifiedPath = string.Join('/', toJoin);
        
        return "/" + simplifiedPath;
    }
    
    
    public string SimplifyPathUnoptimized(string path) 
    {
        StringBuilder sb = new StringBuilder();
        ResetStringBuilder(sb);
        int currentIndex = 0;
        int lastCharIndex = path.Length - 1;
        List<string> toJoin = new List<string>();
        
        while(currentIndex <= lastCharIndex)
        {
            int start = path.IndexOf('/', currentIndex);
            int end = path.IndexOf('/', start+1);
            
            if(end != -1)
            {
                string currentString = ProcessPathPart(path, start, end);
                ParsePathPart(currentString, toJoin);
                // we must increment the index
                currentIndex = end; 
            }
            else
            {
                // this is the last part to process!
                string currentString = ProcessPathPart(path, start, path.Length);
                ParsePathPart(currentString, toJoin);
                break;
            }            
        }
        
        string simplifiedPath = string.Join('/', toJoin);
        
        return "/" + simplifiedPath;
    }
    
    public void ParsePathPart(string currentString, List<string> toJoin)
    {
        if(currentString == "..")
        {
            //we remove the last added thing
            if(toJoin.Count > 0)
                toJoin.RemoveAt(toJoin.Count - 1);
        }
        else if(string.IsNullOrEmpty(currentString)
               || currentString == ".")
        {
            return;
        }
        else
        {
            toJoin.Add(currentString);
        }
    }
    
    public void ResetStringBuilder(StringBuilder sb)
    {
        sb.Clear();
        // every path starts with a single slash
        sb.Append('/');
    }
    
    public string ProcessPathPart(string path, int start, int end)
    {
        // start and end are exclusive!
        var currentString = path.Substring(start+1, end-start-1);
        //Console.WriteLine(currentString);
        return currentString;
    }
}