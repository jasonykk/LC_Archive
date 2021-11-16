public class Solution 
{
    public IList<string> LetterCombinations(string digits) 
    {
        // set up a dictionary with mapping of each number to the individual characters
        // iterate over digits and add them to the output
        
        List<string> toReturn = new List<string>();
        
        if(digits == null || digits.Length == 0)
            return toReturn;        
        
        // build up the dictionary
        Dictionary<char, List<char>> lookup = new Dictionary<char, List<char>>();
        lookup.Add('2', new List<char>(){'a', 'b', 'c'});
        lookup.Add('3', new List<char>(){'d', 'e', 'f'});
        lookup.Add('4', new List<char>(){'g', 'h', 'i'});
        lookup.Add('5', new List<char>(){'j', 'k', 'l'});
        lookup.Add('6', new List<char>(){'m', 'n', 'o'});
        lookup.Add('7', new List<char>(){'p', 'q', 'r', 's'});
        lookup.Add('8', new List<char>(){'t', 'u', 'v'});
        lookup.Add('9', new List<char>(){'w', 'x', 'y', 'z'});
        
        // iterate
        foreach(var num in digits)
        {
            List<string> temp = new List<string>();
            var currentSetOfChars = lookup[num];
            // we must "add on" the new chars to previous ones
            if(toReturn.Count > 0)
            {
                foreach(var st in toReturn)
                {
                    foreach(var chars in currentSetOfChars)
                    {
                        string current = st + chars;
                        //Console.WriteLine(current);
                        temp.Add(current);
                    }
                }
                // update toReturn with the latest values
            }
            else
            {
                foreach(var chars in currentSetOfChars)
                {
                    //Console.WriteLine(chars);
                    temp.Add(chars.ToString());
                }
            }
            toReturn = temp;
        }
        
        
        return toReturn;
    }
}