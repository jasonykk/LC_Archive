public class Solution 
{
    public int MinJumps(int[] arr) 
    {
        /*
        Build a graph for the array. We also want to mark the locations of all nodes that share the same value.
        This helps when "jumping". If we do BFS and all nodes that share the same value is the next node, we can find the "end" faster
        */
        
        int totalLength = arr.Length;
        
        // if there is 0 or 1 elements, we have no need for jumps
        if(totalLength <= 1)
            return 0;
        
        // find all locations for all nodes so that we can make jumps O(n) time, O(n) space as we keep track of all index locations for all values
        Dictionary<int, List<int>> indexLocations = new Dictionary<int, List<int>>();        
        for(int i = 0; i < totalLength; i++)
        {
            if(indexLocations.TryGetValue(arr[i], out var linkedList))
            {
                // tack on the location at the back
                linkedList.Add(i);
            }
            else
            {
                var newList = new List<int>();
                newList.Add(i);
                indexLocations.Add(arr[i], newList);
            }
        }
        
        // prepare list for work
        var indexesToCheck = new List<int>();
        // at the starting position or root
        indexesToCheck.Add(0);
        // we use a set to make sure we don't do repeated work 
        HashSet<int> visitedIndexes = new HashSet<int>();
        int steps = 0;
        
        // keep processing while we have indexes to check (via BFS search) - at most O(n)
        while(indexesToCheck.Count > 0)
        {
            var nextList = new List<int>();
            
            foreach(var index in indexesToCheck)
            {
                if(index == totalLength - 1)
                    return steps;
                
                //if we didnt find the end yet, lets check the that we can reach from here
                foreach(var relatedIndex in indexLocations[arr[index]])
                {
                    if(!visitedIndexes.Contains(relatedIndex))
                    {
                        visitedIndexes.Add(relatedIndex);
                        nextList.Add(relatedIndex);
                    }
                }
                
                // since we're done with this done, we don't parse it again (if the graph returns here, we're repeating work!)
                indexLocations[arr[index]] = new List<int>();
                
                // check neighbors of this index
                if(index+1 < totalLength && !visitedIndexes.Contains(index+1))
                {
                    visitedIndexes.Add(index+1);
                    nextList.Add(index+1);
                }
                
                if(index-1 > 0 && !visitedIndexes.Contains(index-1))
                {
                    visitedIndexes.Add(index-1);
                    nextList.Add(index-1);
                }
                
            }
            
            // once we process all the current indexes, replace it
            indexesToCheck = nextList;
            steps += 1;
            
        }
        
        // we should not get here. throw exception?
        throw new Exception("Invalid arr");
        
    }
}