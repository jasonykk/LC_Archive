public class Solution 
{
    public int FindCircleNum(int[][] isConnected) 
    {
        HashSet<int> completedCities = new HashSet<int>();
        int toReturn = 0;
        
        for(int i = 0; i < isConnected.Length; i++)
        {
            if(!completedCities.Contains(i))
            {
                // add in the current city first
                var workStack = new Stack<int>();
                workStack.Push(i);
                
                while(workStack.Count > 0)
                {
                    var currentCity = workStack.Pop();
                    // check for all cities in the stack
                    for(int j = 0; j < isConnected[currentCity].Length; j++)
                    {
                        // we must not have seen that city yet
                        if(isConnected[currentCity][j] == 1
                          && !completedCities.Contains(j))
                        {
                            completedCities.Add(j);
                            workStack.Push(j);
                        }

                    }
                }
                
                // increment now
                toReturn += 1; 
            }
        }
        
        
        return toReturn;
    }
}