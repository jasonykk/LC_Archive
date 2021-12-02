public class Solution 
{
    public int LongestCommonSubsequence(string text1, string text2) 
    {
        int[,] dp = new int[text1.Length+1,text2.Length+1];
        
        for(int i = 1; i <= text1.Length; i++)
        {
            for(int j = 1; j <= text2.Length; j++)
            {
                if(text1[i-1] == text2[j-1])
                {
                    // add 1 to the max we've found without it
                    dp[i,j] = dp[i-1,j-1] + 1;
                }
                else
                {
                    // it's the max of the previous comparison or without the current char at all
                    dp[i,j] = Math.Max(dp[i-1,j], dp[i,j-1]);
                }
            }
        }
        
        return dp[text1.Length,text2.Length];
        
        
    }
}