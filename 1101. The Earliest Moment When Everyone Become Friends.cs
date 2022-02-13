public class Solution 
{
    public int EarliestAcq(int[][] logs, int n) 
    {
        CustomComparer comparer = new CustomComparer();
        // sort based on timestamp
        Array.Sort(logs, comparer);
        
        // create hashsets until we have a hashset of size n-1
        HashSet<HashSet<int>> groups = new HashSet<HashSet<int>>();
        for(int i = 0; i < n; i++)
        {
            var newGroup = new HashSet<int>();
            newGroup.Add(i);
            groups.Add(newGroup);
        }
                
        // go through the logs and find the groups the persons belong to. merge those groups
        foreach(var log in logs)
        {
            var group1 = GetGroupWithPerson(log[1], groups);
            var group2 = GetGroupWithPerson(log[2], groups);
            
            if(group1 != group2)
            {
                var newGroup = new HashSet<int>(group1);
                newGroup.UnionWith(group2);

                //Console.WriteLine($"group1:{group1.Count}, group2:{group2.Count}, newGroup:{newGroup.Count}, p1:{log[1]}, p2:{log[2]}");

                if(newGroup.Count == n)
                {
                    return log[0];
                }

                // remove old groups
                groups.Remove(group1);
                groups.Remove(group2);

                // add new group
                groups.Add(newGroup);
            }
            
        }
        
        
        return -1;
        
    }
    
    public HashSet<int> GetGroupWithPerson(int person, HashSet<HashSet<int>> groups)
    {
        foreach(var group in groups)
        {
            if(group.Contains(person))
                return group;
        }
        throw new Exception("Illegal person found");
    }
    
    
    public void PrintLogs(int[][] logs)
    {
        StringBuilder sb = new StringBuilder();
        foreach(var log in logs)
        {
            sb.AppendLine($"{log[0]}, {log[1]}, {log[2]}");
        }
        Console.WriteLine(sb.ToString());
        Console.WriteLine("######");
    }
    
}

public class CustomComparer : IComparer<int[]>
{
    // Sort based on the timestamp
    public int Compare(int[] x, int[] y)
    {
        return x[0].CompareTo(y[0]);
    }
}