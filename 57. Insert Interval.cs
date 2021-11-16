public class Solution 
{
    public int[][] Insert(int[][] intervals, int[] newInterval) 
    {
        // get the start/end values
        int start = newInterval[0];
        int end = newInterval[1];
        
        //Console.WriteLine($"start:{start}, end:{end}");
        
        List<int[]> tempList = new List<int[]>();
        int counter = 0;
        
        // iterate while we're "under" the starting new interval
        while(counter < intervals.Length)
        {
            if(intervals[counter][1] < start)
            {
                tempList.Add(intervals[counter]);
                counter += 1;
            }
            else
            {
                break;
            }
        }
        
        //Console.WriteLine($"counter:{counter}");
        
        // we reached a point where we may begin merging
        while(counter < intervals.Length)
        {
            // we keep "merging" intervals while the beginning  is less or equal to the end
            if(intervals[counter][0] <= end) 
            {
                start = Math.Min(start, intervals[counter][0]);
                end = Math.Max(end, intervals[counter][1]);
                counter += 1;
            }
            else
            {
                break;
            }
        }
        
        //Console.WriteLine($"counter:{counter}, start:{start}, end:{end}");
        
        // add the interval
        tempList.Add(new int[]{start, end});
        
        // add any remainder        
        while(counter < intervals.Length)
        {
            tempList.Add(intervals[counter]);
            counter += 1;
        }
        
        return tempList.ToArray();
        
    }
    
    
    public int[][] Insert2(int[][] intervals, int[] newInterval) 
    {
        int start = newInterval[0];
        int end = newInterval[1];
        //Console.WriteLine($"start:{start}, end:{end}");
        
        HashSet<int> focusedIntervalIndexes = new HashSet<int>();
        
        bool foundStart = false;
        bool foundEnd = false;
        
        for(int i = 0; i < intervals.Length; i++)
        {
            if(foundStart && foundEnd)
                break;
            
            int currentStart = intervals[i][0];
            int currentEnd = intervals[i][1];
            
            // the smallest now is bigger than our interval, we can quit
            if(currentStart > end)
            {
                break;
            }
                        
            // if start fits nicely in the current interval, add it
            if(start >= currentStart && start <= currentEnd)
            {
                focusedIntervalIndexes.Add(i);
                foundStart = true;
            }
            
            // if we reach an interval that's larger than start but we haven't found start, this is a good beginnig
            if(start < currentStart && !foundStart)
            {
                focusedIntervalIndexes.Add(i);
                foundStart = true;
            }
            
            // if end fits nicely in the interval, add it
            if(end >= currentStart && end <= currentEnd)
            {
                focusedIntervalIndexes.Add(i);
                foundEnd = true;
            }
            
            // if we found the start but not the end, add this to intervals to replace
            if(foundStart && !foundEnd)
                focusedIntervalIndexes.Add(i);
            
            
        }
        
        int[] toInsert = newInterval;
        if(focusedIntervalIndexes.Count > 0)
        {
            // assuming we found any intervals, sort their indexes
            List<int> finalizedIntervals = focusedIntervalIndexes.ToList();
            finalizedIntervals.Sort();

            // get the associated interval and find the smallest/largest value
            int currentSmallestIntervalValue = intervals[finalizedIntervals[0]][0];
            int currentLargestIntervalValue = intervals[finalizedIntervals[finalizedIntervals.Count - 1]][1];

            int smallest = Math.Min(start, currentSmallestIntervalValue);
            int largest = Math.Max(end, currentLargestIntervalValue);
            // update the interval to be inserted
            toInsert = new int[]{smallest, largest};
        }
        
        List<int[]> tempList = new List<int[]>();
        bool added = false;
        
        // add in all intervals we want
        for(int i = 0; i < intervals.Length; i++)
        {
            // if its not in the list to be replaced we can consider adding
            if(!focusedIntervalIndexes.Contains(i))
            {
                int currentStart = intervals[i][0];
                int currentEnd = intervals[i][1];
                
                // if this is an interval that comes after what we have, slot in our interval first
                if(!added && currentStart > end)
                {
                    tempList.Add(toInsert);
                    added = true;
                }
                
                tempList.Add(intervals[i]);
            }
            else if(!added)
            {
                added = true;
                tempList.Add(toInsert);
            }
                
        }
        
        // if we havent added it, add it now
        if(!added)
        {
            // we need to double check if we should add it at the beginning vs at the end of the list
            if(tempList.Count > 0 && tempList[0][0] > toInsert[0])
            {
                var newList = new List<int[]>();
                newList.Add(toInsert);
                if(tempList[tempList.Count - 1][1] > toInsert[1])
                    newList.AddRange(tempList);
                return newList.ToArray();                
            }
            else
                tempList.Add(toInsert);
        }
        
        return tempList.ToArray();
    }
}