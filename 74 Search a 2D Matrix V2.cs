public class Solution 
{
    public bool SearchMatrix(int[][] matrix, int target) 
    {
        // binary search along rows (calc index and see which value is closest)
        // binary search along cols (calc index and see which value is matches)
        // this saves more memory but is much slower than V1
        
        int low = 0; 
        int high = matrix.Length - 1;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            
            if(matrix[mid][0] > target)
            {
                high = mid - 1;
            }
            else if(matrix[mid][0] < target)
            {
                low = mid + 1;
            }
            else 
            {
                // we lucked out and the number was in the starting position of a row
                return true;
            }
        }
        
        int rowToUse = high;
        // what happens if its smaller than the first ever value?
        if(rowToUse < 0)
            return false;
        
        // reset our low/high values for binary search on col
        low = 0; 
        high = matrix[rowToUse].Length - 1;
        
        while(low <= high)
        {
            int mid = (low + high) / 2;
            
            if(matrix[rowToUse][mid] > target)
            {
                high = mid - 1;
            }
            else if(matrix[rowToUse][mid] < target)
            {
                low = mid + 1;
            }
            else 
            {
                // we found the number
                return true;
            }
        }
        
        return false;
        
        
    }
}