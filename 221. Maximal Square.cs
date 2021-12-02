public class Solution 
{
    public int MaximalSquare(char[][] matrix) 
    {
        int[,] dp = new int[matrix.Length+1, matrix[0].Length+1];
        int maxSide = 0;
        
        // populate the initial column
        for(int i = 0; i < matrix.Length; i++)
        {
            if(matrix[i][0] == '1')
            {
                dp[i,0] = 1;
                maxSide = 1;
            }
        }
        // populate the initial row
        for(int i = 0; i < matrix[0].Length; i++)
        {
            if(matrix[0][i] == '1')
            {
                dp[0,i] = 1;
                maxSide = 1;
            }
        }
        
        // iterate through and 
        for(int i = 1; i < matrix.Length; i++)
        {
            for(int j = 1; j < matrix[i].Length; j++)
            {
                if(matrix[i][j] == '1')
                {
                    // check left, top and diagonal
                    // if all are >= 1, take the min and increment by 1 to set the current value
                    if(dp[i-1,j] >= 1 && 
                       dp[i,j-1] >= 1 &&
                       dp[i-1,j-1] >= 1)
                    {
                        var minOfNeighbors = Math.Min(Math.Min(dp[i-1,j], dp[i,j-1]), dp[i-1,j-1]);
                        dp[i,j] = 1 + minOfNeighbors;
                    }
                    else
                    {
                        dp[i,j] = 1;
                    }
                    maxSide = Math.Max(maxSide, dp[i,j]);
                }
                else
                {
                    dp[i,j] = 0;
                }
            }
        }
        
        return maxSide * maxSide;
        
    }
}