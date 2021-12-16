/*
See leetcode solution explanation: https://leetcode.com/problems/minimum-height-trees/solution/
Discussion: https://leetcode.com/problems/minimum-height-trees/discuss/76055/Share-some-thoughts

Essentially, there can only be at most 2 nodes in the tree that has the shortest height if it was the root
Given so, we mark all the nodes with only a single edge and remove them from the list of edges
If the remaining edges from the removed node is now 1, thats a new leaf.
We loop through until we have only 2 or less nodes left and that is the answer

*/

public class Solution 
{        
    public IList<int> FindMinHeightTrees(int n, int[][] edges) 
    {
        Dictionary<int, HashSet<int>> edgeLookup = new Dictionary<int, HashSet<int>>();
        
        // populate the lookup
        foreach(var edge in edges)
        {
            int node1 = edge[0];
            int node2 = edge[1];
            
            if(edgeLookup.ContainsKey(node1))
            {
                edgeLookup[node1].Add(node2);
            }
            else
            {
                var tempList = new HashSet<int>();
                tempList.Add(node2);
                edgeLookup.Add(node1, tempList);
            }
            
            if(edgeLookup.ContainsKey(node2))
            {
                edgeLookup[node2].Add(node1);
            }
            else
            {
                var tempList = new HashSet<int>();
                tempList.Add(node1);
                edgeLookup.Add(node2, tempList);
            }
        }
        
        List<int> nodesWithSingleEdge = new List<int>();
        foreach(var kvp in edgeLookup)
        {
            if(kvp.Value.Count == 1)
                nodesWithSingleEdge.Add(kvp.Key);            
        }
        
        
        int minEdgeSize = 0;
        int remainingNodes = n;
        
        while(remainingNodes > 2)
        {
            // remove the current leaf nodes from the count
            remainingNodes -= nodesWithSingleEdge.Count;
            
            // remove them from the list of edges as well and build new set
            List<int> nodesWithSingleEdgeReplacement = new List<int>();
            
            foreach(var node in nodesWithSingleEdge)
            {
                foreach(var connectedNode in edgeLookup[node])
                {
                    // we remove it from the neighbor node
                    edgeLookup[connectedNode].Remove(node);
                    if(edgeLookup[connectedNode].Count == 1)
                        nodesWithSingleEdgeReplacement.Add(connectedNode);
                    break;
                }
            }
            
            nodesWithSingleEdge = nodesWithSingleEdgeReplacement;
        }
        
        if(nodesWithSingleEdge.Count == 0)
            return new List<int>() {0};
        else
            return nodesWithSingleEdge;
        
    }
    
}