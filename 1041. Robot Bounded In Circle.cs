public class Solution 
{
    public bool IsRobotBounded(string instructions) 
    {
        // set up directions
        Dictionary<int, int[]> directions = new Dictionary<int, int[]>();
        // north
        directions.Add(0, new int[]{0,1});
        // west
        directions.Add(1, new int[]{-1,0});
        // south
        directions.Add(2, new int[]{0,-1});
        // east
        directions.Add(3, new int[]{1,0});
        
        // initialize starting direction and position
        int currentDirection = 0;
        int[] currentPosition = new int[]{0,0};
        
        // loop through and see final position
        foreach(var instruction in instructions)
        {
            if(instruction == 'L' || instruction == 'R')
            {
                currentDirection = GetNewDirection(currentDirection, instruction);
                //Console.WriteLine($"currentDirection: currentDirection:{currentDirection}");
            }
            else
            {
                currentPosition = Move(currentPosition, directions[currentDirection]);
                //Console.WriteLine($"CurrentPos: x:{currentPosition[0]}, y:{currentPosition[1]}");
            }
        }       
        
        //Console.WriteLine($"Final Pos: x:{currentPosition[0]}, y:{currentPosition[1]}");
        
        if(currentPosition[0] == 0 && currentPosition[1] == 0)
            return true;
        
        if(currentDirection != 0)
            return true;
        
        return false;
    }
    
    public int[] Move(int[] currentPosition, int[] movement)
    {
        currentPosition[0] += movement[0];
        currentPosition[1] += movement[1];
        return currentPosition;
    }
    
    public int GetNewDirection(int currentDirection, char turn)
    {
        if(turn == 'L')
        {
            currentDirection -= 1;
            if(currentDirection < 0)
                return 3;
            else
                return currentDirection;
        }        
        else if(turn == 'R')
        {
            currentDirection += 1;
            if(currentDirection > 3)
                return 0;
            else
                return currentDirection;
        }
        
        // this should not happen
        throw new Exception("illegal char");
    }
    
    
    
}