public class Solution 
{
    public int[][] KClosest(int[][] points, int k) 
    {
        return BasicSortAndReturnK(points, k);
    }
    
    public int[][] QuickSelect(int[][] points, int k) 
    {
        int left = 0;
        int right = points.Length - 1;
        int pivotIndex = points.Length - 1;
        
        while(pivotIndex < k)
        {
            pivotIndex = QuickSelectPartition(points, left, right);
            if(pivotIndex < k)
            {
                left = pivotIndex;
            }
            else
            {
                right = pivotIndex - 1;
            }
        }
        
        int[][] toReturn = new int[k][];
        
        for(int i = 0; i < k; i++)
        {
            toReturn[i] = points[i];
        }
        
        return toReturn;
        
    }
    
    public int QuickSelectPartition(int[][] points, int left, int right) 
    {
        int[] pivot = GetPivot(points, left, right);
        int pivotDistance = GetSquaredDistance(pivot);
        while(left < right)
        {
            if(GetSquaredDistance(points[left]) > pivotDistance)
            {
                int[] temp = points[left];
                points[left] = points[right];
                points[right] = temp;
                right -= 1;
            }
            else
            {
                left += 1;
            }
        }
        
        // if we're under the pivot, keep going 
        while(GetSquaredDistance(points[left]) < pivotDistance)
        {
            left += 1;
        }
        
        return left;
    }
    
    public int GetSquaredDistance(int[] point)
    {
        return (point[0] * point[0]) + (point[1] * point[1]);
    }
    
    public int[] GetPivot(int[][] points, int left, int right) 
    {
        int mid = left + (right - left) / 2;
        return points[mid];
    }
    
    
    public int[][] BasicSortAndReturnK(int[][] points, int k) 
    {
        var customComparer = new CustomComparer();
        Array.Sort(points, customComparer);

        int[][] toReturn = new int[k][];

        for(int i = 0; i < k; i++)
        {
            toReturn[i] = points[i];
        }

        return toReturn;
    }
}


public class CustomComparer: IComparer<int[]>
{
    public int Compare(int[] a, int[] b)
    {
        // we can do without the sqrt calculations since the comparisons are against origin. the square distance will suffice
        var aDistance = Math.Pow(a[0], 2) + Math.Pow(a[1], 2);
        var bDistance = Math.Pow(b[0], 2) + Math.Pow(b[1], 2);
        
        return aDistance.CompareTo(bDistance);
    }

}