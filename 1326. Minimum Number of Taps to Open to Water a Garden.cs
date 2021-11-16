public class Solution 
{
    public int MinTaps(int n, int[] ranges) 
    {
        // is this a dp problem?
        // at each stage, what are the possible taps that can be covered
        // we need to calculate the values at each index as we go
        
        // the value in this array would be the "right-most" fountain range
        int[] coveredFountains = new int[ranges.Length];
        
        // go through each fountain + their ranges, and update coveredFountains with the associated values (larger ranges would overwrite smaller ones)
        for(int i = 0; i < ranges.Length; i++)
        {
            var currentRange = ranges[i];
            
            // we don't get any benefit of going earlier than the 0th index since thats outside of the garden range we care about
            var leftMostIndex = Math.Max(0, i - currentRange);
            // we do not care if the range is further than the garden (n)
            var rightMostIndex = Math.Min(n, i + currentRange);

            // update the leftMostIndex with the larger rightMostIndex (or keep its existing value if its larger)
            //Console.WriteLine($"leftMostIndex:{leftMostIndex}, rightMostIndex:{rightMostIndex}");
            coveredFountains[leftMostIndex] = Math.Max(rightMostIndex, coveredFountains[leftMostIndex]);
            
        }
        
        // we can now iterate over coveredFountains and pick the "largest" coverage fountain
        
        int right = coveredFountains[0];
        int toReturn = 1;
        int nextRight = 0;
        
        for(int i = 1; i < coveredFountains.Length; i++)
        {
            var maxRange = coveredFountains[i];
            nextRight = Math.Max(nextRight, maxRange);
            
            if(i > right)
            {
                // we have a hole in coverage
                return -1;
            }
                
            if(i == right)
            {
                toReturn += 1;
                right = nextRight;
            }
            
            if(right == n)
                break;
        }
        
       return toReturn;
        
        
        
    }
}