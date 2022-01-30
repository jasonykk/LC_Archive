public class Solution 
{    
    public int CanCompleteCircuit(int[] gas, int[] cost) 
    {
        /*
        Calculate the "cost" as we go. If its a positive number, assume we can "use" it going forward
        There is no need to loop since we keep on tracking the total gas needed as we go
            if at the end its a negative value, it doesn't matter where we start at as it'll constantly not be enough to loop
        Update the start if the gas tank goes < 0 at any time. The start would be the next possible station
        */
        
        int gasNeededFromStart = 0;
        int currentGas = 0;
        int startIndex = 0;
        
        for(int i = 0; i < gas.Length; i++)
        {
            gasNeededFromStart += gas[i] - cost[i];
            currentGas += gas[i] - cost[i];
            
            // if we have a negative current gas, this was not a valid start point so we start again at the next stop
            if(currentGas < 0)
            {
                startIndex = i +1;
                currentGas = 0;
            }
            
        }
        
        if(gasNeededFromStart >= 0)
            return startIndex;
        else
            return -1;
    }
}