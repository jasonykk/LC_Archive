public class Solution 
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr) 
    {
        // sort the array first, we should get the smallest difference this way and can also return it in ascending order
        Array.Sort(arr);
        
        List<IList<int>> toReturn = new List<IList<int>>();
        int smallestAbsDiff = Int32.MaxValue;
        
        for(int i = 0; i < arr.Length - 1; i++)
        {
            int currentDifference = Math.Abs(arr[i] - arr[i+1]);
            
            if(currentDifference < smallestAbsDiff)
            {
                // clean the return list
                toReturn = new List<IList<int>>();
                
                // add the current pair                
                var newPair = new List<int>() { arr[i], arr[i+1] };
                toReturn.Add(newPair);
                
                // update the smallest diff
                smallestAbsDiff = currentDifference;
            }
            else if(currentDifference == smallestAbsDiff)
            {
                // if the difference is the same, add it in
                var newPair = new List<int>() { arr[i], arr[i+1] };
                toReturn.Add(newPair);
            }
        }
        
        return toReturn;
        
    }
}