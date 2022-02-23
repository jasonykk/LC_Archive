public class Solution 
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target) 
    {
        /*
        Use backtracking for this
        For each value in candidates, we keep adding the same value until we reach the target OR overshoot it
        when either happens, either add the combination or backtrack
            test next values until the end
        so from 0th position, we will check all values to the right
        from n-1 position, it will only consider n-1 and n.
            any combinations of n-1 and previous values should have already been considered.
        */
        HashSet<IList<int>> toReturn = new HashSet<IList<int>>();
        LinkedList<int> combination = new LinkedList<int>();
        BackTracking(target, combination, 0, candidates, toReturn);
        
        return toReturn.ToList();
    }
    
    public void BackTracking(int remainder, LinkedList<int> combination, int start, int[] candidates, HashSet<IList<int>> toReturn)
    {
        if(remainder == 0)
        {
            // if we have nothing left to deduct, we found a valid combination
            toReturn.Add(new List<int>(combination));
            return;
        }
        else if(remainder < 0)
        {
            // we've deducted TOO MUCH. exit without ending
            return;
        }
        
        // if we get here, we have more to deduct, continue
        for(int i = start; i < candidates.Length; ++i)
        {
            // add number to combination
            combination.AddLast(candidates[i]);
            
            // since we've a new value, deduct it from remainder, and begin from that location
            BackTracking(remainder - candidates[i], combination, i, candidates, toReturn);
            
            // once we've done digging with the existing value, go next by backtracking
            combination.RemoveLast();
        }
        
        
    }
    
}