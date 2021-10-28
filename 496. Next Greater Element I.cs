public class Solution 
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2) 
    {
        // loop over nums1, find the same value in nums2 then begin search from there
        int[] toReturn = new int[nums1.Length];
        for(int i = 0; i < nums1.Length; i++)
        {
            var currentVal = nums1[i];
            for(int j = 0; j < nums2.Length; j++)
            {
                var comparedVal = nums2[j];
                if(currentVal == comparedVal)
                {
                    int toAdd = -1;
                    for(int k = j+1; k < nums2.Length; k++)
                    {
                        if(nums2[k] > comparedVal)
                        {
                            toAdd = nums2[k];
                            break;
                        }
                    }
                    toReturn[i] = toAdd;
                }
            }
        }
        
        return toReturn;
        
        
    }
}