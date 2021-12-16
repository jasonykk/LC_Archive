public class Solution 
{
    public int MinMeetingRooms(int[][] intervals) 
    {
        // sort based on the starting/ending times
        int[] startTimes = new int[intervals.Length];
        int[] endTimes = new int[intervals.Length];
        
        for(int i = 0; i < intervals.Length; i++)
        {
            startTimes[i] = intervals[i][0];
            endTimes[i] = intervals[i][1];
        }
        
        Array.Sort(startTimes);
        Array.Sort(endTimes);
        
        int startPtr = 0;
        int endPtr = 0;
        int usedRooms = 0;
        
        foreach(var meeting in startTimes)
        {
            // see if we have a room that is "done". The ending time has to be less or equal to the start time
            if(startTimes[startPtr] >= endTimes[endPtr])
            {
                endPtr += 1;
                usedRooms -= 1;
            }
            usedRooms += 1;
            startPtr += 1;            
        }
        return usedRooms;
    }
}
