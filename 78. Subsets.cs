public class Solution 
{
    public IList<IList<int>> Subsets(int[] nums) 
    {
        List<IList<int>> toReturn = new List<IList<int>>();
        // we always add an empty list
        toReturn.Add(new List<int>());
        
        string binary = "";
        string minBinary = "";
        int maxLength = nums.Length;
        for(int i = 0; i < maxLength; i++)
        {
            binary += "1";
            minBinary += "0";
        }
        
        //Console.WriteLine($"binary:{binary}, minBinary:{minBinary}");
        
        while(binary != minBinary)
        {
            List<int> currentList = new List<int>();
            for(int i = 0; i < binary.Length; i++)
            {
                if(binary[i] == '1')
                {
                    currentList.Add(nums[i]);
                }
            }
            toReturn.Add(currentList);
            
            // decrement the binary value
            binary = DecrementBinaryString(binary, maxLength);
            //Console.WriteLine($"updated binary:{binary}");
        }        
        
        return toReturn;
        
    }
    
    public string DecrementBinaryString(string input, int maxLength)
    {
        var val = Convert.ToInt32(input, 2);
        val -= 1;
        var newBinary = Convert.ToString(val, 2);
        if(newBinary.Length < maxLength)
        {
            return newBinary.PadLeft(maxLength, '0');
        }
        else
            return newBinary;
    }
}