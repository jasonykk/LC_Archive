public class Solution 
{
    int colLength;
    int rowLength;
    List<int[]> directions;
    
    public int LargestIsland(int[][] grid) 
    {
        // prepare stock values
        int toReturn = 0;
        colLength = grid[0].Length;
        rowLength = grid.Length;
        
        // add 4 cardinal directions for easier processing
        directions = new List<int[]>();
        directions.Add(new int[]{-1, 0});
        directions.Add(new int[]{1, 0});
        directions.Add(new int[]{0, 1});
        directions.Add(new int[]{0, -1});
        
        // idToSize to keep track of each ID to it's size (+2 because ID cannot be 0/1 since those are water/land markers already)
        int[] idToSize = new int[(colLength*rowLength) + 2];      
        
        // contains the processed tiles (default to 0 so everything is unprocessed, 1 means we've seen it)
        int[,] gridCheck = new int[rowLength,colLength];
        
        // set the starting ID  ( 0 means unprocessed, 1 means processed (but still empty). so our ID has to start from 2)
        int currentId = 2;
        
        // parse the entire input grid and save the size of each island found (O m*n)
        for(int x = 0; x < rowLength; x++)
        {
            for(int y = 0; y < colLength; y++)
            {
                // only proceed if we've not processed this tile yet 
                if(gridCheck[x,y] == 0)
                {
                    if(grid[x][y] == 0)
                    {
                        // if the point in the input grid is also 0, we only need to mark that we've processed it
                        gridCheck[x,y] = 1;
                    }
                    else
                    {          
                        // the point in the grid is part of an island, mark it with the current ID
                        gridCheck[x,y] = currentId;
                        // search current island size based on the swap
                        var taggedSize = MarkAdjacentIslands(grid, gridCheck, currentId, x, y);

                        // include the base node (taggedSize does not count the original node)
                        idToSize[currentId] = (taggedSize + 1);
                        
                        // we've saved the island size, increment to a new ID
                        currentId += 1;
                    }
                }
            }
        }
        
        
        HashSet<int> idsToConsider;
        
        // go through the input grid again, this time only looking for when the input point is 0  (O m*n)
        // if that was flipped, see if any of the surrounding islands can be connected or if its just an increment of 1
        // we can easily do this by checking the ID of a particular point based on gridCheck that we populated earlier
        for(int x = 0; x < rowLength; x++)
        {
            for(int y = 0; y < colLength; y++)
            {
                if(grid[x][y] == 0)
                {
                    //get all neighbor coordinates and calculate island size if exists
                    idsToConsider = new HashSet<int>();
                                        
                    foreach(var direction in directions)
                    {
                        int newX = x + direction[0];
                        int newY = y + direction[1];

                        if(newX >= 0 && newX < rowLength        // valid X 
                           && newY >=0 && newY < colLength      // valid Y
                           && gridCheck[newX,newY] >= 2)        // has a valid ID (starts from 2)
                        {
                            idsToConsider.Add(gridCheck[newX, newY]);
                        }
                    }
                    
                    // at minimum the size is 1 because we flipped the node to an island
                    var currentSize = 1;
                    
                    // go through all found islands (if any), and add their sizes.                 
                    foreach(var ids in idsToConsider)
                    {
                        currentSize += idToSize[ids];
                    }
                    
                    // update the value to return if its a larger size
                    if(toReturn < currentSize)
                        toReturn = currentSize;
                }
                
            }
        }
        
        // if after everything, there is no result to return that means the entire grid was 1's 
        // because we only check for stuff to flip (0's in input)
        if(toReturn == 0)
            return rowLength * colLength;
        
        return toReturn;
    }
    
    // Mark adjacent islands with currentId. Returns the size of the island tagged
    // Also updates gridCheck to ensure we do not do double work
    public int MarkAdjacentIslands(int[][] grid, int[,] gridCheck, int id, int x, int y)
    {
        var toReturn = 0;
        
        foreach(var direction in directions)
        {
            int newX = x + direction[0];
            int newY = y + direction[1];
            
            if(newX >= 0 && newX < rowLength    // valid X 
               && newY >=0 && newY < colLength  // valid Y
               && gridCheck[newX,newY] < 2)     // we have not processed it yet
            {
                if(grid[newX][newY] == 1)
                {
                    gridCheck[newX,newY] = id;
                    toReturn += MarkAdjacentIslands(grid, gridCheck, id, newX, newY);
                    toReturn += 1;
                }
            }
        }
        return toReturn;
    }
    
    
}