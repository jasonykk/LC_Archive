public class LRUCache 
{
    Dictionary<int, LinkedListNode<int>> nodeLookup;
    LinkedList<int> lruList;
    int capacity;

    public LRUCache(int capacity) 
    {
        /*
        Cannot use SortedDictionary or SortedList as the lookup for those are O(logN)
        Dictionary + LinkedList
        LinkedList has O(1) remove (if we have node reference) and O(1) insert at start/end
        Use Dictionary with reference to the actual node so we can get it in O(1)
        */
        
        nodeLookup = new Dictionary<int, LinkedListNode<int>>();
        lruList = new LinkedList<int>();
        this.capacity = capacity;        
    }
    
    public int Get(int key) 
    {
        // first see if we can find it in the lookup
        if(nodeLookup.TryGetValue(key, out var node))
        {
            // see if we may have removed it last time
            if(node.List == null)
            {
                // it was, remove it's reference in the lookup
                nodeLookup.Remove(key);
                return -1;
            }
            else
            {
                // we know it exists, since it's been used now, lets move it to the front of the LinkedList
                lruList.Remove(node);
                lruList.AddFirst(node);

                // now that it's been updated, return the value
                return node.Value;
            }
        }
        else
        {
            return -1;
        }
    }
    
    public void Put(int key, int value) 
    {
        // see if it currently exists in the lookup
        if(nodeLookup.TryGetValue(key, out var node))
        {
            // we must check again if the node still is valid
            if(node.List == null)
            {
                nodeLookup.Remove(key);
            }
            else
            {
                lruList.Remove(node);
                // enter the value right at the start of lru list
                lruList.AddFirst(value);
                // update the node for the associated key
                nodeLookup[key] = lruList.First; 
                return;
            }
        }
        
        // it doesn't exist so it's a new insert, see if we have capacity
        if(lruList.Count >= capacity)
        {
            // remove the least used             
            lruList.RemoveLast();
        }            
        // enter the value right at the start of lru list
        lruList.AddFirst(value);
        // add it to the lookup as well
        nodeLookup.Add(key, lruList.First); 
        
          
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */