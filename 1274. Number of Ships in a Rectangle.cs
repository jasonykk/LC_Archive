/**
 * // This is Sea's API interface.
 * // You should not implement it, or speculate about its implementation
 * class Sea {
 *     public bool HasShips(int[] topRight, int[] bottomLeft);
 * }
 */

class Solution 
{
	/*
	Use divide and conquer to find the positions
	Since hasSea is only a single check on whether or not a ship exists, we should sparesly use it
		
	*/
	
	
    HashSet<string> totalPoints;
    
    public int CountShips(Sea sea, int[] topRight, int[] bottomLeft) 
    {
        totalPoints = new HashSet<string>();
        Helper(sea, topRight, bottomLeft);        
        return totalPoints.Count;
    }
    
    public void Helper(Sea sea, int[] topRight, int[] bottomLeft) 
    {
        if(bottomLeft[0] > topRight[0] || bottomLeft[1] > topRight[1])
            return;
        
        if(sea.HasShips(topRight, bottomLeft))
        {
            // we have at least 1 ship in the area, lets divide up and test out where we may have ships
            int midX = (topRight[0] + bottomLeft[0]) / 2;
            int midY = (topRight[1] + bottomLeft[1]) / 2;

            //Console.WriteLine($"topRight:[{topRight[0]},{topRight[1]}],  bottomLeft:[{bottomLeft[0]},{bottomLeft[1]}],  midX:[{midX},{midY}]");

            if(bottomLeft[0] == topRight[0]
                    && bottomLeft[1] == topRight[1])
            {
                //Console.WriteLine($"same point with valid ship");
                totalPoints.Add($"{bottomLeft[0]},{bottomLeft[1]}");
                return;
            }
            else
            {
                // top right quad
                Helper(sea, topRight, new int[] { midX+1, midY+1});
                // top left quad
                Helper(sea, new int[] { midX, topRight[1]}, new int[] { bottomLeft[0], midY+1});
                // bottom left quad
                Helper(sea, new int[] { midX, midY}, bottomLeft);
                // bottom right quad            
                Helper(sea, new int[] { topRight[0], midY}, new int[] { midX+1, bottomLeft[1]});
            }
        }
    }
    
    
}