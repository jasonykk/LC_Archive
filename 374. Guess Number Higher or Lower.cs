/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is lower than the guess number
 *			      1 if num is higher than the guess number
 *               otherwise return 0
 * int guess(int num);
 */

public class Solution : GuessGame 
{
    public int GuessNumber(int n) 
    {
        // binary search the results
        
        // optimizations
        if(guess(n) == 0)
            return n;
        if(guess(0) == 0) 
            return 0;
            
        return BinarySearch(1, n);
        
    }
    
    public int BinarySearch(int start, int end)
    {
        int mid = start + (end - start) / 2;
        int result = guess(mid);
        if(result == 0)
            return mid;
        else if(result == -1)
        {
            //real is smaller
            return BinarySearch(1, mid-1);
        }
        else
            return BinarySearch(mid+1, end);
    }
    
}