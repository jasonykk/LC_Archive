public class Solution 
{
    public bool CanPlaceFlowers(int[] flowerbed, int n) 
    {
        /*
        we need a count for adjacent 0's. At worst, we will scan the entire array but if we find the count == n we can stop and return
        we can compare previous (if valid) and next (if valid) IF the current is 0        
        */
        
        if(n == 0)
            return true;
        
        int canPlant = 0;
        
        for(int i = 0; i < flowerbed.Length; i++)
        {
            // only care if its empty
            if(flowerbed[i] == 0)
            {
                // see if the neighbors are [left & right]
                if(((i-1 >= 0 && flowerbed[i-1] == 0) || i == 0)
                  && ((i+1 < flowerbed.Length-1 && flowerbed[i+1] == 0) || i == flowerbed.Length-1))
                {
                    // update count
                    canPlant += 1;
                    // set that we "planted" so we dont double count
                    flowerbed[i] = 1;
                    // check if we can exit
                    if(canPlant == n)
                        return true;
                }
            }
        }
        
        
        return false;
        
        
    }
}