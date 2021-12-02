public class Solution 
{
    List<IList<int>> results;
    
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) 
    {
        results = new List<IList<int>>();
        
        var existingResults = new List<int> { 0 };
        AllPathsSourceTarget(graph, existingResults, 0);
        
        return results;
    }
    
    
    public void AllPathsSourceTarget(int[][] graph, List<int> existingResults, int currentIndex) 
    {
        if(currentIndex == graph.Length - 1)
        {
            // we are done, we've found an end so we need to save this result
            results.Add(new List<int>(existingResults));
            return;
        }
        else
        {
            var currentOutputs = graph[currentIndex];

            for(int i = 0; i < currentOutputs.Length; i++)
            {
                // add the current element we're going to
                existingResults.Add(currentOutputs[i]);
                AllPathsSourceTarget(graph, existingResults, currentOutputs[i]);
                // remove last added
                existingResults.RemoveAt(existingResults.Count - 1);
            }
        }        
    }
    
}