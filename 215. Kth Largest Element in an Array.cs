public class Solution 
{
    int[] nums;
    Random rand;    
    
    /*
    Quick Select would depend on our luck when selecting the pivots. 
    TIME: on average this is O(N) but worst case is O(N^2)
    Space: O(1)
    
    */
    
    public int FindKthLargest(int[] nums, int k) 
    {
        this.nums = nums;
        rand = new Random();
        // we use nums.Length-k since QuickSelect sorts it from smallest to largest.
        // k'th largest element = N-k smallest element
        return QuickSelect(0, nums.Length-1, nums.Length-k);
    }
    
    public int QuickSelect(int left, int right, int k)
    {
        if(left == right)
            return nums[left];
        
        // randomly pick a pivot point to go with
        var randomVal = rand.Next(right - left); 
        // since left is the min, we add the random value to it
        int pivotIndex = left + randomVal;
        
        // partition the range based on the pivot index and get the actual "place" the value is supposed to be
        pivotIndex = Partition(left, right, pivotIndex);
        
        // if the pivot value matches k, we've found what we want
        if(k == pivotIndex)
        {
            return nums[k];
        }
        else if(k < pivotIndex)
        {
            return QuickSelect(left, pivotIndex-1, k);
        }
        else
        {
            return QuickSelect(pivotIndex+1, right, k);
        }
        
    }
    
    public int Partition(int left, int right, int pivotIndex)
    {
        int pivotVal = nums[pivotIndex];
        // move the pivot value all the way to the right first
        SwapValues(pivotIndex, right);
        int currentIndex = left;
        
        //move smaller elements left of the pivot. all right elements will get "pushed" to the right
        for(int i = left; i <= right; i++)
        {
            if(nums[i] < pivotVal)
            {
                SwapValues(currentIndex, i);
                currentIndex += 1;
            }
        }
        
        // all smaller elements are now on the right side of the actual pivot point
        // move the pivot value to its actual place
        SwapValues(currentIndex, right);
        
        // return the index of the pivot point
        return currentIndex;
    }
    
    public void SwapValues(int index1, int index2)
    {
        int temp = nums[index1];
        nums[index1] = nums[index2];
        nums[index2] = temp;
    }
    
    /*
    
    public int FindKthLargestUsingSD(int[] nums, int k) 
    {
        // Use a sorted dictionary to keep the values. We also must count the # of times they appear
        // first loop is O(n)
        // each lookup and insert is O(logN) so its O(2*logN) = O(logN)
        // we then have to loop through another time to find the k'th value but at most k times since we check increment at each time
        
        // TIME final is O(nlogn + k)
        // SPACE is n as we save each value (if they are all diff)
        
        SortedDictionary<int, int> sortedValues = new SortedDictionary<int, int>();
        
        foreach(var num in nums)
        {
            // multiply by -1 since we want the kth largest (and SortedDictionary by default goes smallest to largest)
            int toSave = num * -1;
            if(!sortedValues.ContainsKey(toSave))
                sortedValues.Add(toSave, 1);
            else
                sortedValues[toSave] += 1;
        }
        
        // now that we've iterated, pop the kth largest element
        int currentK = 1;
        int toReturn = 0;
        bool foundValue = false;
        foreach(var savedVal in sortedValues)
        {
            if(currentK == k)
            {
                toReturn = savedVal.Key;
                foundValue = true;
            }
            else
            {
                int increment = 0;
                while(increment < savedVal.Value)
                {
                    if(currentK == k)
                    {
                        toReturn = savedVal.Key;
                        foundValue = true;
                        break;
                    }
                    currentK += 1;
                    increment += 1;
                }
            }
            
            if(foundValue)
                break;
        }
        
        // we need to undo the special multiplication we did
        return toReturn * -1;
    }
    
    */
}