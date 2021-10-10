public class Solution 
{
    public bool IsValidSudoku(char[][] board) 
    {
        // use a hashset to keep track of everything that we've found
        // utilize adding to the hashset to tell us we've found it before
        
        HashSet<string> lookup = new HashSet<string>();
        
        // call each row and col while saving to the lookup
        for(int row = 0; row < board.Length; row++)
        {
            // call each col
            for(int col = 0; col < board[0].Length; col++)
            {
                if(board[row][col] != '.')
                {
                    // adding to hashset returns false if already exists
                    var currentValue = int.Parse((board[row][col]).ToString());
                    if(!lookup.Add($"row{row}:{currentValue}") ||
                        !lookup.Add($"col{col}:{currentValue}") ||
                        !lookup.Add($"{row/3}x{col/3}:{currentValue}"))
                        return false;
                }
            }
        }
        return true;
    }
        
}