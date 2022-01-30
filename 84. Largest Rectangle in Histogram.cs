public class Solution 
{
    public int LargestRectangleArea(int[] heights) 
    {
        Stack<int> currentWork = new Stack<int>();        
        // we add in -1 as the "last" in case we need to calculate the length of the entire of heights
        currentWork.Push(-1);
        int maxArea = Int32.MinValue;
        int length = heights.Length;
        
        // go from left to right
        for(int i = 0; i < length; i++)
        {
            // we are okay with an equality check here since if the next one is the same height, we'll just recalculate it anyway with the new width
            while(currentWork.Peek() != -1 && 
                 (heights[currentWork.Peek()] >= heights[i]))
            {
                int currentHeight = heights[currentWork.Pop()];
                int currentWidth = i - currentWork.Peek() - 1;
                maxArea = Math.Max(maxArea, currentHeight * currentWidth);                
            }
            currentWork.Push(i);
        }
        
        // last process in the event theres anything left
        while(currentWork.Peek() != -1)
        {
            int currentHeight = heights[currentWork.Pop()];
            int currentWidth = length - currentWork.Peek() - 1;
            maxArea = Math.Max(maxArea, currentHeight * currentWidth);    
        }
        
        return maxArea;
        
    }
}
