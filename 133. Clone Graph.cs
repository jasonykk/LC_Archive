/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution 
{
    Dictionary<int, Node> nodes;
    
    public Node CloneGraph(Node node) 
    {
        if(node == null)
            return node;
        
        if(node.neighbors.Count == 0)
            return new Node(node.val);
            
        nodes = new Dictionary<int, Node>();
        var startingNode = new Node(node.val);
        Helper(startingNode, node);
        
        return startingNode;
    }
    
    public void Helper(Node currentNode, Node originalNode)
    {
        if(!nodes.ContainsKey(currentNode.val))
        {
            nodes.Add(currentNode.val, currentNode);
        }
        
        // check all its associated neighbors and make sure they exist
        foreach(var neighbor in originalNode.neighbors)
        {
            if(nodes.TryGetValue(neighbor.val, out var relatedNode))
            {
                // ensure that the reverse is added
                relatedNode.neighbors.Add(currentNode);
            }
            else
            {
                // the neighbor does not exist. create it
                var newNode = new Node(neighbor.val);
                
                // add the current copy as a neighbor
                newNode.neighbors.Add(currentNode);
                
                // recurse this node
                Helper(newNode, neighbor);
            }
        }
    }
}