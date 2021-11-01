public class Solution 
{
    public void Solve(char[][] board) 
    {
        Dictionary<string, int[]> allOs = new Dictionary<string, int[]>();
        HashSet<string> specials0s = new HashSet<string>();
        List<int[]> directions = new List<int[]>();
        // north
        directions.Add(new int[] { -1, 0 });
        // south
        directions.Add(new int[] { 1, 0 });
        // east
        directions.Add(new int[] { 0, 1 });
        // west
        directions.Add(new int[] { 0, -1 });
        
        int lastRow = board.Length - 1;
        int lastCol = board[0].Length - 1;
            
        // find all boundary 0's and 0's connected to them
        for(int row = 0; row < board.Length; row++)
        {
            for(int col = 0; col < board[row].Length; col++)
            {
                var locString = GetLocationString(row, col);
                
                // if we've previously seen this node, we can ignore it
                if(!specials0s.Contains(locString))
                {
                    // we only care about boundary 0's
                    if((row == 0 || col == 0 || row == lastRow || col == lastCol) && board[row][col] == 'O')
                    {
                        var locsToCheck = new Queue<int[]>();
                        locsToCheck.Enqueue(new int[2] { row, col });

                        while(locsToCheck.Count > 0)
                        {
                            var currentLoc = locsToCheck.Dequeue();
                            var locRow = currentLoc[0];
                            var locCol = currentLoc[1];
                            var currentLocString = GetLocationString(locRow, locCol);

                            if(!specials0s.Contains(currentLocString))
                            {
                                // add current location to special O's (cannot flip!)
                                specials0s.Add(currentLocString);

                                // check all valid directions for more O's
                                foreach(var direction in directions)
                                {
                                    var newRow = locRow + direction[0];
                                    var newCol = locCol + direction[1];
                                    if(newRow >= 0 && newRow <= lastRow
                                      && newCol >= 0 && newCol <= lastCol
                                      && board[newRow][newCol] == 'O'
                                      && !specials0s.Contains(GetLocationString(newRow, newCol)))
                                    {
                                        locsToCheck.Enqueue(new int[2] { newRow, newCol });
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        // we haven't seen this 0 yet connected to a boundary, add it to consideration
                        allOs.Add(locString, new int[2] { row, col});  
                    }
                }

            }
        }
        
        // now that we have processed the entire board, check all0's and see if any of them needs to be flipped
        foreach(var kvp in allOs)
        {
            if(!specials0s.Contains(kvp.Key))
            {
                board[kvp.Value[0]][kvp.Value[1]] = 'X';
            }
        }
            
        
    }
    
    public string GetLocationString(int x, int y)
    {
        return $"{x},{y}";
    }
    
}

