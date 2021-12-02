public class Solution 
{
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList) 
    {
        int firstPointer = 0;
        int secondPointer = 0;
        List<int[]> toReturn = new List<int[]>();        
        
        while(firstPointer < firstList.Length 
             && secondPointer < secondList.Length)
        {
            var arr1 = firstList[firstPointer];
            var arr2 = secondList[secondPointer];         
            
            // check if there are any overlaps 
            if(arr1[0] >= arr2[0] 
               && arr1[0] <= arr2[1])
            {
                // arr1 overlaps with arr2
                int maxStart = Math.Max(arr1[0], arr2[0]);
                int minEnd = Math.Min(arr1[1], arr2[1]);
                toReturn.Add(new int[] {maxStart, minEnd});
            }
            else if(arr2[0] >= arr1[0] 
               && arr2[0] <= arr1[1])
            {
                // arr2 overlaps with arr1
                int maxStart = Math.Max(arr2[0], arr1[0]);
                int minEnd = Math.Min(arr2[1], arr1[1]);
                toReturn.Add(new int[] {maxStart, minEnd});
            }
            
            //increment the smaller ending
            if(arr1[0] == arr2[0]
              && arr1[1] == arr2[1])
            {
                // if equal, increment both
                firstPointer += 1;
                secondPointer += 1;  
            }
            else if(arr1[1] < arr2[1])
            {
                firstPointer += 1;
            }
            else
            {
                secondPointer += 1;  
            }
                         
        }
        
        return toReturn.ToArray();
    }
    
    public bool HasOverlap(int[] arr1, int[] arr2)
    {
        if(arr1[0] >= arr2[0] 
           && arr1[0] <= arr2[1])
        {
            // arr1 overlaps with arr2
            return true;
        }
        if(arr2[0] >= arr1[0] 
           && arr2[0] <= arr1[1])
        {
            // arr2 overlaps with arr1
            return true;
        }
        return false;
    }
    
}