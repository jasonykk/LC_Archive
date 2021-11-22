public class Solution 
{
    public int FindLongestChain(int[][] pairs) 
    {
        /*
        We sort the array first O(nlogn)
        Once it's fully sorted, we can find the largest increasing subsequence (LIS) - O(n^2)
        
        
        */
        
        var comparer = new Comparer();
        Array.Sort(pairs, comparer);
        
        int[] results = new int[pairs.Length];
        
        for(int i = 0; i < pairs.Length; i++)
        {
            for(int j = 0; j < i; j++)
            {
                // the right of j must be smaller than left of i for us to consider this
                if(pairs[j][1] < pairs[i][0])
                {
                    results[i] = Math.Max(results[i], results[j] + 1);
                }
            }
        }
        
        int toReturn = 0;
        foreach(var val in results)
        {
            toReturn = Math.Max(toReturn, val);
        }
        
        return toReturn+1;
        
    }
}

public class Comparer : IComparer<int[]>
{
    public int Compare(int[] p1, int[] p2)
    {
        //we only need to compare the 2nd item since left [0] is always smaller than right [1]
        return p1[1].CompareTo(p2[1]);
    }
}