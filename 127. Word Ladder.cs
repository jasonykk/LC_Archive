public class Solution 
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) 
    {
        // all words are constrainted to the same length
        int wordLength = beginWord.Length;
        
        // dictionary to keep track of combinations
        Dictionary<string, List<string>> combinations = new Dictionary<string, List<string>>();
        
        foreach(var word in wordList)
        {
            // get each word combination
            for(int i = 0; i < wordLength; i++)
            {
                string currentCombination = word.Substring(0, i) + '*' + word.Substring(i+1, wordLength-i-1);
                if(combinations.TryGetValue(currentCombination, out var relatedCombinations))
                {
                    relatedCombinations.Add(word);
                }
                else
                {
                    List<string> related = new List<string>();
                    related.Add(word);
                    combinations.Add(currentCombination, related);
                }
            }
        }
        
        // now that we have all possible combinations, we must try to find a way to reach the end
        Queue<Tuple<string, int>> todo = new Queue<Tuple<string, int>>();
        todo.Enqueue(new Tuple<string, int>(beginWord, 1));
        
        // have a dictionary to keep track of which words have been visited
        Dictionary<string, bool> visited = new Dictionary<string, bool>();
        visited.Add(beginWord, true);
        
        while(todo.Count > 0)
        {
            var currentWork = todo.Dequeue();
            var word = currentWork.Item1;
            var level = currentWork.Item2;
             
            // for the given word, try out all combinations for adjacent words
            for(int i = 0; i < wordLength; i++)
            {
                string currentCombination = word.Substring(0, i) + '*' + word.Substring(i+1, wordLength-i-1);
                
                // see if the word exists in our lookup
                if(combinations.TryGetValue(currentCombination, out var relatedCombinations))
                {
                    foreach(var validAdjacentWord in relatedCombinations)
                    {
                        // if any of the current adjacent word is the endword, we're done
                        if(validAdjacentWord == endWord)
                            return level+1;
                        
                        // if we did not find the answer, search each adjacent word as work todo
                        if(!visited.ContainsKey(validAdjacentWord))
                        {
                            visited.Add(validAdjacentWord, true);
                            todo.Enqueue(new Tuple<string, int>(validAdjacentWord, level+1));
                        }
                        
                    }
                }
                
            }
            
        }
        
        // if we did not find the endWord while traversing all the combinations, it did not exists
        return 0;
        
    }
}