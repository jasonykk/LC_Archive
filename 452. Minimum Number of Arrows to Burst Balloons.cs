public class Solution 
{
    public int FindMinArrowShots(int[][] points) 
    {
        /*
        Sort based on end times, then start times if draw
        Look at the end of a point, if it overlaps with the next start
            continue until we reach a start that does not overlap.
            since if there is an overlap, shooting at end of P1, will affect P2, P3 ... as long as there is overlap with end <--> start        
        */
        
        if(points.Length == 1)
            return 1;
        
        CustomComparer comparer = new CustomComparer();
        // sort the array
        Array.Sort(points, comparer);
        //PrintArr(points);
        
        // at minimum we always need 1 arrow
        int numArrowsRequired = 1;
        // default to the first endpoint
        int endPoint = points[0][1];
        int totalLength = points.Length;
        
        for(int i = 1; i < totalLength; i++)
        {
            var currentStart = points[i][0];
            var currentEnd = points[i][1];
            
            // we only have work if there is no overlap
            if(endPoint < currentStart)
            {
                // there is no more overlap, we must use an arrow for the new set
                numArrowsRequired += 1;
                endPoint = currentEnd;
            }       
        }
        
        return numArrowsRequired;
    }
    
    public void PrintArr(int[][] arr)
    {
        StringBuilder sb = new StringBuilder();
        foreach(var arrayToPrint in arr)
        {
            sb.Append($"[{arrayToPrint[0]},{arrayToPrint[1]}],");
        }
        Console.WriteLine(sb.ToString());
    }
    
    
}

public class CustomComparer: IComparer<int[]>
{
    public int Compare(int[] x, int[] y)
    {
        var endComparison = x[1].CompareTo(y[1]);
        if(endComparison == 0)
        {
            // compare the start points
            return x[0].CompareTo(y[0]);
        }
        else
        {
            return endComparison;
        }
    }
}