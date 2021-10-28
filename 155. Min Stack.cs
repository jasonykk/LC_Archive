public class MinStack 
{
    private TreeNode head;
       
    public MinStack() 
    {
        
    }
    
    public void Push(int val) 
    {       
        int currentMin = val;
        if(head != null)
            currentMin = Math.Min(head.minSoFar, val);
        var newHead = new TreeNode(val, currentMin, head);
        head = newHead;
    }
    
    public void Pop() 
    {
        head = head.next;
    }
    
    public int Top() 
    {
        return head.val;
    }
    
    public int GetMin() 
    {
        return head.minSoFar;
    }
}

public class TreeNode
{
    public int val;
    public int minSoFar;
    public TreeNode next;
    
    public TreeNode(int val, int minSoFar, TreeNode next = null)
    {
        this.val = val;
        this.minSoFar = minSoFar;
        this.next = next;
    }
    
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */