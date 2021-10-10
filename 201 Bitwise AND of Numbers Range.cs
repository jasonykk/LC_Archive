public class Solution 
{
    public int RangeBitwiseAnd(int left, int right) 
    {
        /*
        see: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators
        right shift operator (>>) removes bits from the right (eg: 101 >>1 becomes 10)
        left shift operator (<<) adds 0 bits from the right and discards the largest bit if passes max (eg: 101 <<1 becomes 1010)
        */
        
        int numOfBitShifts = 0;
        
        // keep getting rid of "small" bits until they match (this is important as the AND operator means both numbers must have all 1's or 0's in same index)
        while(left != right)
        {
            left >>= 1;
            right >>= 1;
            numOfBitShifts += 1;
        }
        
        //once they are matching, we add back to the right (since its the larger number)
        return (right <<= numOfBitShifts);
        
    }
}