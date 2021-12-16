public class Solution 
{
    public int[][] Merge(int[][] intervals) 
    {
        // sort the intervals based on the start times
        var customComparer = new Comparer();
        Array.Sort(intervals, customComparer);
        
        List<int[]> toReturn = new List<int[]>();
        
        int[] prev = new int[] { intervals[0][0], intervals[0][1] };
        // we've already populated the first value so the index pointer starts at 1
        int ptr = 1;
        
        while(ptr < intervals.Length)
        {
            // get the current interval
            var currentInterval = intervals[ptr];
            
            // see if we can merge it in the previous one (if available)
            if(currentInterval[0] > prev[1])
            {
                // if the start time is later than the old end time, there is no merging. Add it toReturn
                toReturn.Add(prev);
                // set prev to be the new interval
                prev = currentInterval;
            }
            else
            {
                // update the end time to be the currentInterval's if its later
                if(currentInterval[1] > prev[1])
                {
                    prev[1] = currentInterval[1];
                }
            }
            
            // increment the pointer before we loop
            ptr += 1;
        }
        
        // add the last interval
        toReturn.Add(prev);
        
        return toReturn.ToArray();        
    }
}

public class Comparer: IComparer<int[]>
{
    public int Compare(int[] a, int[] b)
    {
        // sort by the start times. This is sufficient since if the start times are the same we will merge them anyway
        return a[0].CompareTo(b[0]);        
    }
}