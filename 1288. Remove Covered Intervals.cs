public class Solution 
{
    public int RemoveCoveredIntervals(int[][] intervals) 
    {
        CustomComparer comparer = new CustomComparer();
        // sort intervals by starting then end values
        Array.Sort(intervals, comparer);
        
        // an interval is covered if and only if its within the bound of the previous. use stack for this
        Stack<int[]> validIntervals = new Stack<int[]>();
        validIntervals.Push(intervals[0]);
        
        for(int i = 1; i < intervals.Length; i++)
        {
            var currentInterval = intervals[i];
            // see if the current interval is within 
            var toCompare = validIntervals.Peek();
            
            if(currentInterval[0] >= toCompare[0]
              && currentInterval[1] <= toCompare[1])
            {
                // we can skip as its covered
                continue;
            }
            else
            {
                // it's a valid interval
                validIntervals.Push(currentInterval);
            }            
        }
        
        return validIntervals.Count;
        
    }
    
    public void PrintArr(int[][] arr)
    {
        StringBuilder sb = new StringBuilder();        
        foreach(var range in arr)
        {
            sb.Append($"[{range[0]},{range[1]}],");
        }
        Console.WriteLine(sb.ToString());
    }
    
}

public class CustomComparer: IComparer<int[]>
{
    public int Compare(int[] x, int[] y)
    {
        var start = x[0].CompareTo(y[0]);
        if(start != 0)
        {
            return start;   
        }
        else
        {
            // we return the larger right value first as it'll encompass more things
            return x[1].CompareTo(y[1]) * -1;
        }
    }
}