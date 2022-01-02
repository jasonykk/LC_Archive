public class Solution 
{
    public int[] TwoSum(int[] numbers, int target) 
    {
        int lowPtr = 0;
        int highPtr = numbers.Length - 1;
        
        while(lowPtr < highPtr)
        {
            var currentSum = numbers[lowPtr] + numbers[highPtr];
            if(currentSum == target)
                return new int[] { lowPtr+1, highPtr+1};
            else if(currentSum > target)
            {
                // we're over reduce the highPtr to decrease the overall sum
                while(numbers[highPtr - 1] == numbers[highPtr])
                    highPtr -= 1;
                
                // we reduce 1 more time since we were looking for an equality
                highPtr -= 1;
            }
            else
            {
                // we're less, increase lowPtr to increase the overall sum
                while(numbers[lowPtr + 1] == numbers[lowPtr])
                    lowPtr += 1;
                
                // we reduce 1 more time since we were looking for an equality
                lowPtr += 1;
            }
        }
        
        // given that we should always find an answer, this should throw an exception
        throw new Exception("Answer not found");
        
    }
}