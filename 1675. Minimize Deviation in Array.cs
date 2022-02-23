public class Solution 
{
    public int MinimumDeviation(int[] nums) 
    {
        /*
        even can only decrease
        odd can only increase
        
        first: find the min value among the max of the values (evens are already max while odd must be multiplied up)
        note that we use a priority queue here with the priority being the negative of the value! 
            this way we can get the "largest" value first when iterating later
        */
        
        PriorityQueue<int, int> evens = new PriorityQueue<int, int>();                
        int minValue = Int32.MaxValue;
        
        foreach(var num in nums)
        {
            if (num % 2 == 0) 
            {
                // use a negative for priority!
                evens.Enqueue(num, -num);
                minValue = Math.Min(minValue, num);
            } 
            else 
            {
                int valTouse = num * 2;
                // use a negative for priority!
                evens.Enqueue(valTouse, -valTouse);
                minValue = Math.Min(minValue, valTouse);
            }
        }
        
        int minDeviation = Int32.MaxValue;
        
        // iterate from largest to smallest value saved (given negative priority)
        while (evens.TryDequeue(out int currentValue, out int priority))
        {
            minDeviation = Math.Min(minDeviation, currentValue - minValue);
            
            if (currentValue % 2 == 0) 
            {
                // if the current value is even, we should try making it smaller. add this back to the evens queue to be processed
                int valTouse = currentValue / 2;
                evens.Enqueue(valTouse, -valTouse);
                minValue = Math.Min(minValue, valTouse);
            } 
            else 
            {
                // if the maximum is odd, break and return
                // we can only get a current value that is odd IF we've made it smaller earlier (see above logic where we requeue if its even)
                break;
            }
        }
        
        return minDeviation;
    }
}