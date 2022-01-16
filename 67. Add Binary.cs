public class Solution 
{
    
    public string AddBinary(string a, string b) 
    {
        if(a.Length < b.Length)
        {
            // we always assume that a is longer, call back the method if it is not but swap a and b
            return AddBinary(b, a);
        }
        
        StringBuilder sb = new StringBuilder();
        int carryOverValue = 0;
        
        for(int i = a.Length - 1, j = b.Length - 1; i >= 0; i--, j--)
        {
            int aVal = a[i] - '0';
            int bVal = 0;
            
            // update default value if b is still being parsed
            if(j >= 0)
                bVal = b[j] - '0';
            
            // calculate the new value
            int currentValue = aVal + bVal + carryOverValue;
            carryOverValue = SaveResultAndGetCarryover(sb, currentValue, carryOverValue);
        }

        if(carryOverValue > 0)
            sb.Append(1);
        
        //Console.WriteLine(sb.ToString());
        var arrayToConvert = sb.ToString().ToCharArray();
        Array.Reverse(arrayToConvert);
        return new string(arrayToConvert);        
    }
    
    public int SaveResultAndGetCarryover(StringBuilder sb, int currentValue, int carryOverValue)
    {
        if(currentValue == 3)
        {
            carryOverValue = 1;
            sb.Append(1);
        }
        else if(currentValue == 2)
        {
            carryOverValue = 1;
            sb.Append(0);
        }
        else if(currentValue == 1)
        {
            carryOverValue = 0;
            sb.Append(1);
        }
        else
        {
            carryOverValue = 0;
            sb.Append(0);
        }      
        return carryOverValue;
    }
    
    
    /*
       
    public string AddBinary(string a, string b) 
    {
        long x = Convert.ToInt64(a, 2);
        long y = Convert.ToInt64(b, 2);
        long carryover;
        long result;
        while (y.CompareTo(0) != 0) 
        {
            result = x ^ y;
            // shift left by 1 since the carryover value is moved up by 1
            carryover = (x & y) << 1;
            
            // update the result so we can keep going until there is nothing to carryover
            x = result;
            y = carryover;
        }
        
        return Convert.ToString(x, 2);
    }
    
    
    #############################
    #############################
    #############################
    #############################
    #############################
    
    public string AddBinary(string a, string b) 
    {
        // rudimentary cast but will fail for long values
        // can be int, long, even BigInteger to solve this
        var aCast = Convert.ToInt64(a, 2);
        var bCast = Convert.ToInt64(b, 2);
        return Convert.ToString(aCast + bCast, 2);
    }
    
    
    
    #############################
    #############################
    #############################
    #############################
    #############################
    
    
    
    public string AddBinaryUsingDict(string a, string b) 
    {
        //Use a Dictionary to save every possible combination of a[i] + b[i] + carryover. the result would be value,newCarryover
        //This trades space for not using addition at all        
        
        
        if(a.Length < b.Length)
        {
            // we always assume that a is longer, call back the method if it is not but swap a and b
            return AddBinary(b, a);
        }
        
        // key would be a,b,carryover, value is value,newCarryover
        Dictionary<string, int[]> additionLookup = new Dictionary<string, int[]>();
        additionLookup.Add("0,0,0", new int[] {0,0});
        additionLookup.Add("0,0,1", new int[] {1,0});
        additionLookup.Add("0,1,0", new int[] {1,0});
        additionLookup.Add("1,0,0", new int[] {1,0});
        additionLookup.Add("0,1,1", new int[] {0,1});
        additionLookup.Add("1,1,0", new int[] {0,1});
        additionLookup.Add("1,0,1", new int[] {0,1});
        additionLookup.Add("1,1,1", new int[] {1,1});
        
        StringBuilder sb = new StringBuilder();
        int carryOver = 0;
        
        for(int i = a.Length - 1, j = b.Length - 1; i >= 0; i--, j--)
        {
            int aVal = a[i] - '0';
            int bVal = 0;
            
            // update default value if b is still being parsed
            if(j >= 0)
                bVal = b[j] - '0';
            
            var result = additionLookup[$"{aVal},{bVal},{carryOver}"];
            sb.Append(result[0]);
            carryOver = result[1];            
        }
        
        if(carryOver > 0)
            sb.Append(1);
        
        char[] arr = sb.ToString().ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
        
        
    }
    
    
    
    
    
    #############################
    #############################
    #############################
    #############################
    #############################
    
    
    
    public string AddBinaryParseLongString(string a, string b) 
    {
        if(a.Length < b.Length)
        {
            // we always assume that a is longer, call back the method if it is not but swap a and b
            return AddBinary(b, a);
        }
        
        StringBuilder sb = new StringBuilder();
        int carryOverValue = 0;
        
        // start with b (we must use length - i to find the right value as imbalanced lengths will cause issues otherwise. compare 1100 + 1)
        for(int i = 1; i <= b.Length; i++)
        {
            // calculate the new value
            int currentValue = (a[a.Length - i] - '0') + (b[b.Length - i] - '0') + carryOverValue;
            carryOverValue = SaveResultAndGetCarryover(sb, currentValue, carryOverValue);
        }
        
        if(a.Length != b.Length)
        {
            for(int j = (a.Length - b.Length - 1); j >= 0; j--)
            {
                int currentValue = (a[j] - '0') + carryOverValue;
                carryOverValue = SaveResultAndGetCarryover(sb, currentValue, carryOverValue);
            }
        }

        if(carryOverValue > 0)
            sb.Append(1);
        
        //Console.WriteLine(sb.ToString());
        var arrayToConvert = sb.ToString().ToCharArray();
        Array.Reverse(arrayToConvert);
        return new string(arrayToConvert);        
    }
    
    public int SaveResultAndGetCarryover(StringBuilder sb, int currentValue, int carryOverValue)
    {
        if(currentValue == 3)
        {
            carryOverValue = 1;
            sb.Append(1);
        }
        else if(currentValue == 2)
        {
            carryOverValue = 1;
            sb.Append(0);
        }
        else if(currentValue == 1)
        {
            carryOverValue = 0;
            sb.Append(1);
        }
        else
        {
            carryOverValue = 0;
            sb.Append(0);
        }      
        return carryOverValue;
    }
    
    */
    
}