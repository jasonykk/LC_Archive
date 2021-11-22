public class Solution 
{
    EnvelopeComparer comparer;
    LisComparer comparer2;
    Dictionary<int, int> dp;
        
    public int MaxEnvelopes(int[][] envelopes) 
    {
        /*
        https://leetcode.com/problems/russian-doll-envelopes/discuss/82763/Java-NLogN-Solution-with-Explanation
        
        Enhancement on what is already present. Sort the array
        Use https://leetcode.com/problems/longest-increasing-subsequence/ to get the count
        This is possible since we only care for envelopes getting larger in size!
        Note that sorting is not in the traditional sense, if there is a tie in the width, we want to sort in decreasing value for heigt
            Reason is LIS will take it as increasing value where we cant fit it if the width is the same
            [3,1][3,2][3,3] LIS = 3 but in actual fact it should be 1. To solve this: [3,3],[3,2],[3,1] will correctly return 
            
        Sorting is O(nlogn)
        Searching is O(n^2) since we have 2 for loops
        Space is O(n) since we account for each position in envelopes length
        
        */
        
        int[] dpLIS = new int[envelopes.Length];
                
        // sort the input
        comparer2 = new LisComparer();
        Array.Sort(envelopes, comparer2);
        //PrintOut(envelopes);
        
        for(int i = 0; i < envelopes.Length; i++)
        {
            for(int j = 0; j < i; j++)
            {
                // only update if i is larger
                if(envelopes[j][0] < envelopes[i][0]
                  && envelopes[j][1] < envelopes[i][1])
                {
                    dpLIS[i] = Math.Max(dpLIS[i], dpLIS[j] + 1);
                }
            }
        }
        
        int toReturn = 0;
        foreach(var val in dpLIS)
        {
            toReturn = Math.Max(toReturn, val);
        }
        // add a 1 since we never counted the actual value itself
        return toReturn+1;
    }
    
    public int MaxEnvelopesBaseDP(int[][] envelopes) 
    {
        /*
        Since we need to russian doll the envelopes, we would need to compare envelopes of increasing size
        If we sort, we'll know that at least the next envelope is "larger" than what's already there.
            This is no guarantee though as addressing by width may cause us to lose out on the biggest count
                eg: [1,1] [2,100] [3,3] [4,4] [5,5]
                above is sorted but if width 2 is picked we will never get the rest
        
        To solve this, iterate over every envelope as we increase in size and use that as a starting point. O(n) time
        we then compare with every single value and see if it'll fit and choose that as a new starting point O(n^2)
        to reduce the time, we use Dictionary<int, int> to save results we previously calculated (if present)
        
        */
        dp = new Dictionary<int, int>();
        for(int i = 0; i < envelopes.Length; i++)
        {
            dp.Add(i, 0);
        }
                
        // sort the input
        comparer = new EnvelopeComparer();
        Array.Sort(envelopes, comparer);
        //PrintOut(envelopes);
        
        int toReturn = Int32.MinValue;
        for(int i = 0; i < envelopes.Length; i++)
        {
            var totalCount = Helper(envelopes, i);
            toReturn = Math.Max(toReturn, totalCount);
        }
        
        return toReturn;
    }
    
    public int Helper(int[][] envelopes, int index)
    {
        if(index >= envelopes.Length)
            return 0;
        
        if(dp[index] > 0)
        {
            return dp[index];
        }
        
        //starting point is after the index. we only look at envelopes larger than where we are
        for(int i = index+1; i < envelopes.Length; i++)
        {
            // if i is larger than the index, we can try to see what happens if we choose it
            if(envelopes[index][0] < envelopes[i][0] 
               && envelopes[index][1] < envelopes[i][1])
            {
                var totalCount = Helper(envelopes, i);
                dp[index] = Math.Max(dp[index], totalCount);
            }
        }
        
        // we finish by assuming the current index was chosen. This is regardless of anything else that exists        
        dp[index] += 1;
        
        return dp[index];
    }
    
    public void PrintOut(int[][] envelopes)
    {
        StringBuilder sb = new StringBuilder();
        foreach(var ev in envelopes)
        {
            sb.Append($"[{ev[0]},{ev[1]}]");
        }
        Console.WriteLine(sb.ToString());
    }
    
}

public class LisComparer : IComparer<int[]>
{
    public int Compare(int[] e1, int[] e2)
    {
        // we first compare the width
        var widthResult = e1[0].CompareTo(e2[0]);
                
        // if its even, compare the height
        if(widthResult == 0)
        {
            var heightResult = e1[1].CompareTo(e2[1]);
            if(heightResult == 0)
                return heightResult;
            else
            {
                // we want the opposite result here!
                return -1 * heightResult;
            }
        }
        else
        {
            return widthResult;
        }
    
    }
}

    
public class EnvelopeComparer : IComparer<int[]>
{
    public int Compare(int[] e1, int[] e2)
    {
        // we first compare the width
        var widthResult = e1[0].CompareTo(e2[0]);
        
        // if its even, compare the height
        if(widthResult == 0)
        {
            return e1[1].CompareTo(e2[1]);
        }
        else
        {
            return widthResult;
        }
        
    }

}