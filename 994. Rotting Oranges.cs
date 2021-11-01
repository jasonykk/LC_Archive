public class Solution 
{
    public int OrangesRotting(int[][] grid) 
    {
        HashSet<string> allOnes = new HashSet<string>();
        List<Pos> newWork = new List<Pos>();
        int currentMin = 0;
        bool atLeastOneZero = false;
        
        // first pass to save all ones
        for(int x = 0; x < grid.Length; x++)
        {
            for(int y = 0; y < grid[0].Length; y++)
            {
                if(grid[x][y] == 1)
                {
                    allOnes.Add($"{x},{y}");
                }
                else if(grid[x][y] == 2)
                    newWork.Add(new Pos(x, y));           
                else
                    atLeastOneZero = true;
            }
        }
        
        // if we do not have any 2's, we will never have anything to spoil
        if(newWork.Count == 0)
        {
            // if we have ones, it means its impossible to spoil them
            if(allOnes.Count > 0)
                return -1;
            else
                return 0;
        }        
        
        while(newWork.Count > 0 && allOnes.Count > 0)
        {
            // reset what indexes we're working with
            var currentWork = new List<Pos>();
            currentWork.AddRange(newWork);
            // clear out any old work so we can add new ones
            newWork = new List<Pos>();
            
            // iterate through each 2's and mark the new ones that are ones
            foreach(var currentPos in currentWork)
            {
                var toCheck = GetAdjacentPos(grid, currentPos.x, currentPos.y);
                foreach(var tempPos in toCheck)
                {
                    // we only care if it's a one.
                    if(allOnes.Contains(tempPos.ToString()))
                    {
                        // remove it from allOnes and add it to newWork
                        allOnes.Remove(tempPos.ToString());
                        newWork.Add(tempPos);       
                    }
                }
            }
            
            currentMin += 1;
        }
        
        return allOnes.Count == 0 ? currentMin : -1;
        
        
    }
    
    public List<Pos> GetAdjacentPos(int[][] grid, int x, int y)
    {
        //Console.WriteLine($"x:{x}, y:{y}, grid.Length:{grid.Length}, grid[x].Length:{grid[x].Length}");
        
        var toReturn = new List<Pos>();
        
        // check north
        if(x-1 >= 0)
        {
            toReturn.Add(new Pos(x-1, y));
        }
        
        // check south
        if(x+1 < grid.Length)
        {
            toReturn.Add(new Pos(x+1, y));
        }
        
        // check west
        if(y-1 >= 0)
        {
            toReturn.Add(new Pos(x, y-1));
        }
        
        // check east
        if(y+1 < grid[x].Length)
        {
            toReturn.Add(new Pos(x, y+1));
        }        
        
        return toReturn;
    }
}

public class Pos
{
    public int x;
    public int y;
    
    public Pos(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    
    public override string ToString()
    {
        return $"{x},{y}";
    }
    
}