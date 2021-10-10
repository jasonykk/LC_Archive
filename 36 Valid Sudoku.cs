public class Solution 
{
    public bool IsValidSudoku(char[][] board) 
    {
        // check each row 1-9 (no repeats)
        // check each col 1-9 (no repeats)
        // check each 3x3 (no repeats)        
        // create func Valid start/end row, start/end col. ensures no dupes and nums between 1-9 only
        
        // call each row
        for(int row = 0; row < board.Length; row++)
        {
            if(!IsValidSubdivision(board, row, row, 0, board[0].Length - 1))
                return false;
        }
        
        // call each col
        for(int col = 0; col < board[0].Length; col++)
        {
            if(!IsValidSubdivision(board, 0, board[0].Length - 1, col, col))
                return false;
        }
        
        // call each 3x3        
        for(int row = 0; row < board.Length; row+=3)
        {
            for(int col = 0; col < board[0].Length; col+=3)
            {
                if(!IsValidSubdivision(board, row, row+2, col, col+2))
                    return false;
            }
        }
        
        return true;
        
        
    }
    
    public bool IsValidSubdivision(char[][] board, int startRow, int endRow, int startCol, int endCol)
    {
        bool[] lookup = new bool[] {true, true, true, true, true, true, true, true, true};
        for(int i = startRow; i <= endRow; i++)
        {
            for(int j = startCol; j <= endCol; j++)
            {
                //Console.WriteLine($"i:{i},   j:{j}");
                var currentValue = board[i][j];
                if(currentValue != '.')
                {
                    var currentValueInt = int.Parse(currentValue.ToString()) - 1;
                    //Console.WriteLine($"currentValueInt:{currentValueInt},   currentValue:{currentValue}");
                    if(!lookup[currentValueInt])
                        return false;
                    else
                        lookup[currentValueInt] = false;
                }
            }
        }
        return true;
    }
    
}