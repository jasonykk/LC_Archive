public class Solution 
{
    public int[] ExclusiveTime(int n, IList<string> logs) 
    {
        /*
        Do we need to keep track of when things stop/start?
            not really. we can just use the index point to determine that
            currentIndex = 0
            at 1:start:2, we can do 2-0 to find that we've done "2" time in 0 id
                1 - 0 + 1 = 2
                    we do 1 because ID 1 STARTS at 2 which means ID 0 "finished/paused" at end of 1 (inclusive)
            update currentIndex = 2
            at 1:end:5, we can find that we spent 
                5 - 2 + 1 = 4        
        */
        
        // stack keeps the ID only
        Stack<int> toProcess = new Stack<int>();
        int[] toReturn = new int[n];
        int currentTime = 0;
        
        foreach(var log in logs)
        {
            var formatArr = log.Split(':');
            int id = Convert.ToInt32(formatArr[0]);
            bool isStart = (formatArr[1] == "start");
            int newTime = Convert.ToInt32(formatArr[2]);
                    
            if(isStart)
            {
                // see if we have something to process in the stack (something to pause and add time to)
                if(toProcess.TryPeek(out int idToPause))
                {
                    // we want to pause/mark the previous ID first up to the new time
                    UpdateTime(toReturn, idToPause, currentTime, newTime);
                }
                
                // add the current id to the stack
                toProcess.Push(id);        
                // set as start index
                currentTime = newTime;       
            }
            else
            {
                // get the paired start
                var poppedId = toProcess.Pop();
                
                UpdateTime(toReturn, poppedId, currentTime, newTime + 1);       
                // since end "finishes" at the end of the second, we must increment the index to be + 1 of the value
                currentTime = newTime+1;     
            }
        }
        
        return toReturn;
        
    }
    
    public void UpdateTime(int[] toReturn, int id, int currentTime, int newTime)
    {
        toReturn[id] += newTime - currentTime;
    }
}