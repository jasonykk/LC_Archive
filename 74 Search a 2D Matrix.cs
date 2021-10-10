public class Solution 
{
    public bool SearchMatrix(int[][] matrix, int target) 
    {
        // given that each row is sorted, and each new row is larger than previous
        // go down rows until we're larger than the target, 
        // then check the previous row if the distance is smaller from front/back and iterate that way
        
        int rowToUse = 0;
        
        for(int row = 0; row < matrix.Length; row++)
        {
            rowToUse = row;
            int firstNum = matrix[row][0];
            if(firstNum > target)
            {                
                rowToUse -= 1;
                break;
            }
        }
        
        // what happens if its smaller than the first ever value?
        if(rowToUse < 0)
            return false;
        
        bool iterateForwards = false;
        int diffWithStart = Math.Abs(matrix[rowToUse][0] - target);
        int diffWithEnd = Math.Abs(matrix[rowToUse][matrix[rowToUse].Length - 1] - target);
        
        if(diffWithStart < diffWithEnd)
        {
            // iterate forwards
            for(int i = 0; i < matrix[rowToUse].Length - 1; i++)
            {
                if(target == matrix[rowToUse][i])
                    return true;
            }
        }
        else
        {
            // iterate backwards
            for(int i = matrix[rowToUse].Length - 1; i >= 0 ; i--)
            {
                if(target == matrix[rowToUse][i])
                    return true;
            }
        }
        
        return false;
        
        
    }
}