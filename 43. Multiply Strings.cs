public class Solution 
{
    public string Multiply(string num1, string num2) 
    {
        StringBuilder sb = new StringBuilder();
		int[] ans = new int[num1.Length + num2.Length - 1];
        
        for(int i = 0; i < num1.Length; i++) 
        {
			for (int j = 0; j < num2.Length; j++) 
            {
				ans[i + j] += (num1[i] - '0') * (num2[j] - '0');
			}
		}
        
        for(int i = ans.Length - 1; i > 0; i--)
        {
            //increment the "next" value by the carryover
            ans[i-1] += ans[i] / 10;
            
            // set the remainder to equal the proper value
            ans[i] = ans[i] % 10;
        }
        
        foreach(var val in ans)
        {
            // we should not include any leading 0s 
            if(sb.Length == 0 && val == 0)   
                continue;
            sb.Append(val);
        }
        
        if(sb.Length == 0)
            return "0";
        
        return sb.ToString();
        
    }
    
    public string Multiply2(string num1, string num2) 
    {
        // rather than do a direct cast, convert each number one value at a time
        double convertedNum1 = 0;
        double convertedNum2 = 0;
        
        foreach(var n in num1)
        {
            convertedNum1 *= 10;
            convertedNum1 += (n - '0');
        }
        
        foreach(var n in num2)
        {
            convertedNum2 *= 10;
            convertedNum2 += (n - '0');
        }
        
        return (convertedNum1 * convertedNum2).ToString();
        
    }
}