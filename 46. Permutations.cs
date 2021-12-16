public class Solution 
{
    List<IList<int>> toReturn;
    
    public IList<IList<int>> Permute(int[] nums) 
    {
        toReturn = new List<IList<int>>();
        Swap(nums, 0);        
        return toReturn;
    }
    
    public void Swap(int[] nums, int start) 
    {
        if(start == nums.Length - 1)
        {
            toReturn.Add(nums.ToList());
            return;
        }
        
        for(int i = start; i < nums.Length; i++)
        {
            //swap the value
            var temp = nums[i];
            nums[i] = nums[start];
            nums[start] = temp;
            
            Swap(nums, start + 1);
            
            // back track
            temp = nums[i];
            nums[i] = nums[start];
            nums[start] = temp;            
        }
    }
    
}