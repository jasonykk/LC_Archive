public class Solution 
{
    public string Convert(string s, int numRows) 
    {
        // iterate through string s
        // start on a full col, add to each row
        // when we reach end of the validRows, start decrementing back to row 0.
        // each decrement should also incrment the col by 1, this creates the zag
        // once we reach 0, we need another full col
        bool fullCol = true;
        int row = 0;
        int col = 0;
        
        // initialize holder
        List<char>[] holder = new List<char>[numRows];
        for(int i = 0; i < numRows; i++)
        {
            holder[i] = new List<char>();
        }
        
        foreach(var ch in s)
        {
            if(fullCol)
            {
                // keep going down the col
                if(row != numRows - 1)
                {
                    holder[row].Add(ch);
                    row += 1;
                }
                else
                {
                    // we start the zag (diagonal)
                    holder[row].Add(ch);
                    fullCol = false;
                    if(row != 0)
                        row -= 1;
                }
            }
            else
            {
                // keep going up till row = 0
                if(row != 0)
                {
                    holder[row].Add(ch);
                    row -= 1;
                }
                else
                {
                    // we start the zig (down the col)
                    holder[row].Add(ch);
                    fullCol = true;
                    if(row < numRows - 1)
                        row += 1;
                }
            }
        }
        
        StringBuilder sb = new StringBuilder();
        foreach(var rowHolder in holder)
        {
            foreach(var ch in rowHolder)
                sb.Append(ch);
        }
        
        return sb.ToString();
    }
}