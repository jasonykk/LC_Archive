public class Solution 
{
    public int[] FindOrder(int numCourses, int[][] prerequisites) 
    {
        /*
        Create an array of length numCourses       
        
        */
        var lookup = PopulateLookup(prerequisites);
        
        if(lookup == null)
        {
            Console.WriteLine("Invalid");
            return new int[0];
        }
        
        // if we get to this point a valid answer is possible. Let's build up our lookup 
        var courseToDependenciesCount = new Dictionary<int, int>();
        var coursesToProcess = new Queue<int>();
        for(int i = 0; i < numCourses; i++)
        {
            if(lookup.TryGetValue(i, out var dependencies))
            {
                courseToDependenciesCount.Add(i, dependencies.Count);
            }
            else
            {
                coursesToProcess.Enqueue(i);
            }
        }
        
        var toReturn = new List<int>();
        // process everything that has no edges
        while(coursesToProcess.Count > 0)
        {
            var currentCourse = coursesToProcess.Dequeue();
            // we can add it directly to be returned because at this point any dependency was already added
            toReturn.Add(currentCourse);
            
            // check for each course we had and see if the dependencies contains the course
            foreach(var courseLookup in lookup)
            {
                if(courseLookup.Value.Contains(currentCourse))
                {
                    // once we find the course to be a dependency, reduce the count
                    var dependentCourse = courseLookup.Key;
                    courseToDependenciesCount[dependentCourse] -= 1;
                    
                    // if there are no more dependency (counts) this can now be added to the queue to be processed
                    if(courseToDependenciesCount[dependentCourse] == 0)
                    {
                        coursesToProcess.Enqueue(dependentCourse);
                    }
                }
            }
        }
        
        if(toReturn.Count == numCourses)
            return toReturn.ToArray();
        else
            return new int[0];
        
    }
    
    public Dictionary<int, HashSet<int>> PopulateLookup(int[][] prerequisites)
    {
        var lookup = new Dictionary<int, HashSet<int>>();
        foreach(var preReq in prerequisites)
        {
            var course = preReq[0];
            var dependency = preReq[1];
            
            // before adding this, check to see if a circular dependency exists
            if(HasCircularDependency(lookup, course, dependency))
            {
                return null;
            }

            if(lookup.ContainsKey(course))
            {
                lookup[course].Add(dependency);
            }
            else
            {
                var dependencies = new HashSet<int>();
                dependencies.Add(dependency);
                lookup.Add(course, dependencies);
            }
        }
        return lookup;
    }
    
    public bool HasCircularDependency(Dictionary<int, HashSet<int>> lookup, int course, int dependency)
    {
        // get the dependencies of the incoming dependency
        if(lookup.TryGetValue(dependency, out var dependencies))
        {
            // if the lookup exists and the course exists in its list, there is circular dependency
            if(dependencies.Contains(course))
            {
                return true;
            }
        }
        
        // if its not in lookup yet, there is no circular dependency
        return false;
    }
    
}