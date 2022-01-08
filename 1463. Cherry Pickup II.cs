public class Solution 
{
    int maxCol;
    
    public int CherryPickup(int[][] grid) 
    {
        maxCol = grid[0].Length;
        int[,,] results = new int[grid.Length, maxCol, maxCol];
        
        // set everything to minimum value so that we know its not yet processed
        for(int row = 0; row < grid.Length; row++)
        {
            for(int col1 = 0; col1 < maxCol; col1++)
            {
                for(int col2 = 0; col2 < maxCol; col2++)
                {
                    results[row, col1, col2] = Int32.MinValue;
                }
            }
        }
        
        return dp(0, 0, maxCol - 1, grid, results);
    }
    
    
    public int dp(int row, int col1, int col2, int[][] grid, int[,,] results)
    {
        // check if we are out of boundary. If so, then this is not a valid combination
        if(col1 < 0 || col1 >= grid[0].Length || col2 >= grid[0].Length || col2 < 0)
            return 0;
        
        // see if the value is already in the cache
        if(results[row, col1, col2] != Int32.MinValue)
            return results[row, col1, col2];
        
        // if we have not exit, return the current cell value
        int currentResult = grid[row][col1];
        
        if(col1 != col2)
            currentResult += grid[row][col2];
        
        // see what posible values are there from here
        int nextMax = 0;
        if(row < grid.Length - 1)
        {
            for(int col1Pos = col1 - 1; col1Pos <= col1 + 1; col1Pos++)
            {
                for(int col2Pos = col2 - 1; col2Pos <= col2 + 1; col2Pos++)
                {
                    nextMax = Math.Max(nextMax, dp(row+1, col1Pos, col2Pos, grid, results));
                }
            }
        }
        
        currentResult += nextMax;
        
        results[row, col1, col2] = currentResult;
        
        return currentResult;
    }
}