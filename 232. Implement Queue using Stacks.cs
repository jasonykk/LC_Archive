public class MyQueue {

    Stack<int> input;
    Stack<int> output;
    
    public MyQueue() {
        input = new Stack<int>();
        output = new Stack<int>();
    }
    
    public void Push(int x) {
        input.Push(x);
    }
    
    public int Pop() {
        // call peek first to ensure we move everything new over to output (will be in FIFO then)
        Peek();
        return output.Pop();
    }
    
    public int Peek() {
        if(output.Count == 0)
        {
            // make sure to transfer everything from input first
            while(input.Count != 0)
                output.Push(input.Pop());
        }
        // we can now return the latest
        return output.Peek();
    }
    
    public bool Empty() {
        return input.Count() == 0 && output.Count() == 0;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */

/*

Non-clean code here

public class MyQueue 
{
    Stack<int> s1;
    Stack<int> s2;
    bool isLIFO;
    

    public MyQueue() 
    {
        s1 = new Stack<int>();
        s2 = new Stack<int>();
        isLIFO = true;
    }
    
    public void Push(int x) 
    {
        if(s1.Count() == 0)
        {
            if(isLIFO)
            {
                s2.Push(x);
            }
            else
            {
                // if we're currently not in LIFO, swap over first before pushing
                while(s2.Count() > 0)
                    s1.Push(s2.Pop());
                s1.Push(x);
                isLIFO = true;
            }
        }
        else
        {
            if(isLIFO)
            {
                s1.Push(x);
            }
            else
            {
                // if we're currently not in LIFO, swap over first before pushing
                while(s1.Count() > 0)
                    s2.Push(s1.Pop());
                s2.Push(x);
                isLIFO = true;
            }
        }
    }
    
    public int Pop() 
    {
        return PopPeekCombination(true);
    }
    
    public int Peek() 
    {
        return PopPeekCombination(false);
    }
    
    public bool Empty() 
    {
        return s1.Count() == 0 && s2.Count() == 0;
    }
    
    public int PopPeekCombination(bool isPop)
    {
        
        if(s1.Count() > 0)
        {
            if(isLIFO)
            {
                // if we're currently not in LIFO, swap over first before popping
                while(s1.Count() > 1)
                    s2.Push(s1.Pop());
                isLIFO = false;
                if(isPop)
                    return s1.Pop();
                else
                {
                    s2.Push(s1.Pop());
                    return s2.Peek();
                }
            }
            else
            {
                if(isPop)
                    return s1.Pop();
                else
                {
                    return s1.Peek();
                }
            }
        }
        else
        {
            if(isLIFO)
            {
                // if we're currently not in LIFO, swap over first before popping
                while(s2.Count() > 1)
                    s1.Push(s2.Pop());
                isLIFO = false;
                if(isPop)
                    return s2.Pop();
                else
                {
                    s1.Push(s2.Pop());
                    return s1.Peek();
                }
            }
            else
            {
                if(isPop)
                    return s2.Pop();
                else
                {
                    return s2.Peek();
                }
            }
        }
    }
    
}



*/