public class Solution 
{
    int[] xDirections = new int[]{0,0,1,-1};
    int[] yDirections = new int[]{1,-1,0,0};
    
    public int ShortestDistance(int[][] grid) 
    {
        /*
        We do not know how many or where the houses are at the start
        have 3 sets
            0 - empty spaces
            1 - houses
            2 - obstacles
            
        find all houses first O(mn)
            
        foreach house, we need to do a BFS to each location 
            maybe use a Queue to track on stuff
            also need a way to track where we've visited. so the distance to a particular spot is based on minimum of its neighbors + 1
        assuming k houses this is O(kmn)
        
        once we've done it for each house, we sum up the distance from each house to that point and keep track of min
        since we consider all valid points this is O(mn)
        
        final time: O(mn + mn)
        
        
        return the min if available (-1 if Int32.MaxValue is the min. this can happen if there is no place to build)
        
        */
        
        int housesFound = 0;
        
        // we create an answer representing the grid itself.
        // the array takes 2 spots, 1 for the distance from houses to that point, and the 2nd for how many houses reached it (in the event 1 house fails to, we can exclude it)
        int[,] distancesForHouses = new int[grid.Length, grid[0].Length];
        int[,] countForHouses = new int[grid.Length, grid[0].Length];
        
        // do a first pass to identify all houses
        for(int x = 0; x < grid.Length; x++)
        {
            for(int y = 0; y < grid[0].Length; y++)
            {
                if(grid[x][y] == 1)
                {
                    housesFound += 1;
                    CalculateDistancesForHouse(grid, new int[]{x,y}, distancesForHouses, countForHouses);
                }
            }
        }
        
        // prepare final result
        int minimumDistance = Int32.MaxValue;
        
        // go through each point in the grid and find the minimum value       
        for(int x = 0; x < grid.Length; x++)
        {
            for(int y = 0; y < grid[0].Length; y++)
            {
                if(grid[x][y] == 0)
                {
                    // make sure that this point is valid (all houses can reach it)
                    if(countForHouses[x,y] == housesFound)
                    {
                        // see if we found a smaller distance
                        minimumDistance = Math.Min(minimumDistance, distancesForHouses[x,y]);
                    }
                }
            }
        }
                
        if(minimumDistance == Int32.MaxValue)
            return -1;
        else
            return minimumDistance;   
    }
    
    public void CalculateDistancesForHouse(int[][] grid, int[] house, int[,] distancesForHouses, int[,] countForHouses)
    {
        bool[,] processedPoints = new bool[grid.Length, grid[0].Length];
        Queue<int[]> pointsToProcess = new Queue<int[]>();
        pointsToProcess.Enqueue(house);
        
        // the house is the origin so its processed by default and has 0 distance
        processedPoints[house[0], house[1]] = true;
        
        int distanceToPoint = 0;
                
        // start processing
        while(pointsToProcess.Count > 0)
        {
            // there is a "level" that takes the same # of steps to process. lets do it all now
            int toProcessCount = pointsToProcess.Count;
            
            for(int i = 0; i < toProcessCount; i++)
            {
                var currentPoint = pointsToProcess.Dequeue();
                int currentX = currentPoint[0];
                int currentY = currentPoint[1];

                if(grid[currentX][currentY] == 0)
                {
                    // set the # of steps to reach this point
                    distancesForHouses[currentX, currentY] += distanceToPoint;
                    // mark that the point can be reached by a new house
                    countForHouses[currentX, currentY] += 1;
                }

                for(int direction = 0; direction < 4; direction++)
                {
                    int newX = currentX + xDirections[direction];
                    int newY = currentY + yDirections[direction];

                    // see if valid grid value
                    if(newX >= 0 && newX < grid.Length && newY >= 0 && newY < grid[newX].Length)
                    {
                        // we should process the point if we have not been there and its an empty plot
                        if(!processedPoints[newX, newY] && grid[newX][newY] == 0)
                        {
                            // mark it as true so we don't accidentaly add it back later
                            processedPoints[newX, newY] = true;
                            pointsToProcess.Enqueue(new int[] {newX, newY});
                        }
                    }                    
                }
            }
            
            // "level" with the same steps have been processed and we can increment the distance for the next round
            distanceToPoint += 1;
        }
            
    }
    
}