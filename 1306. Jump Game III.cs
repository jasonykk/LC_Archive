public class Solution 
{    
    HashSet<int> visited;
    Queue<int> toVisit;
    
    public bool CanReach(int[] arr, int start) 
    {
        visited = new HashSet<int>();
        toVisit = new Queue<int>();
        
        toVisit.Enqueue(start);
        
        while(toVisit.Count > 0)
        {
            var currentIndex = toVisit.Dequeue();
            
            if(!visited.Contains(currentIndex))
            {
                // we only take action if we've not seen it before
                var currentValue = arr[currentIndex];
                if(currentValue == 0)
                    return true;
                
                // add the current index to the list of visited nodes
                visited.Add(currentIndex);
                
                var jumpUp = currentIndex + currentValue;
                var jumpDown = currentIndex - currentValue;

                if(jumpDown >= 0 && !visited.Contains(jumpDown))
                {
                    toVisit.Enqueue(jumpDown);
                }
                if(jumpUp < arr.Length && !visited.Contains(jumpUp))
                {
                    toVisit.Enqueue(jumpUp);
                }
                
                
            }
            
            
        }
        
        return false;
        
    }
}