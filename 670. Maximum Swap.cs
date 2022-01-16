public class Solution 
{
    public int MaximumSwap(int num) 
    {
        // get the number
        List<int> sortedList = num.ToString().Select(charDigit => charDigit - '0').ToList();
        int totalLength = sortedList.Count;
        // create a copy for comparison
        List<int> nonSorted = new List<int>(sortedList);
        
        // sort it 
        sortedList.Sort();
        
        // we now know where the largest to smallest value must be.
        int indexToSwap = -1;
        int largeValueSwapped = -1;
        for(int i = totalLength - 1, j = 0; i >= 0; i--, j++)
        {
            if(sortedList[i] != nonSorted[j])
            {
                // save the non-sorted value for swapping
                indexToSwap = j;
                largeValueSwapped = sortedList[i];
                break;
            }
        }
        
        //Console.WriteLine($"indexToSwap:{indexToSwap}, largeValueSwapped:{largeValueSwapped}");
        
        // the biggest num we can set is ready we now must swap the smallest 
        if(indexToSwap != -1)
        {
            for(int i = totalLength - 1; i >= 0; i--)
            {
                if(nonSorted[i] == largeValueSwapped)
                {
                    // replace the smallest value to swap
                    int temp = nonSorted[indexToSwap];
                    nonSorted[indexToSwap] = largeValueSwapped;
                    nonSorted[i] = temp;
                    break;
                }
            }
            // finally, reform the int and return
            int toReturn = 0;

            for(int i = 0; i < totalLength; i++)
            {
                toReturn = (toReturn * 10) + nonSorted[i];
            }

            return toReturn;
        }
        else
        {
            // there is nothing to swap, return the original value
            return num;
        }
        
        
        
    }
    
    public void PrintArr(List<int> arr)
    {
        StringBuilder sb = new StringBuilder();
        foreach(var dig in arr)
        {
            sb.Append($"{dig},");
        }
        Console.WriteLine(sb.ToString());
    }
}