public class TweetCounts 
{
    // maintain a dictionary for the tweet to lsited times
    // when trying to count the frequency, we must get a frequencyDivisor to decide how we calculate the intervals
    // the response has to be from endTime - startTime as that helps us maintain only intervals within the period provided
    // since the time calculation may not begin at time 0, this is important
    // then for each time recorded earlier, we must subtract the startTime to ensure we calculate the right interval
    Dictionary<string, List<int>> tweetFrequencies;

    public TweetCounts() 
    {
        tweetFrequencies = new Dictionary<string, List<int>>();
    }
    
    public void RecordTweet(string tweetName, int time) 
    {
        if(tweetFrequencies.ContainsKey(tweetName))
        {
            tweetFrequencies[tweetName].Add(time);
        }
        else
        {
            var freqs = new List<int>();
            freqs.Add(time);
            tweetFrequencies.Add(tweetName, freqs);
        }
        
    }
    
    public IList<int> GetTweetCountsPerFrequency(string freq, string tweetName, int startTime, int endTime) 
    {
        List<int> toReturn = new List<int>();
        int frequencyDivisor = 0;
                
        if(freq == "minute")
        {
            frequencyDivisor = 60;
        }
        else if(freq == "hour")
        {
            frequencyDivisor = 3600;
        }
        else if(freq == "day")
        {
            frequencyDivisor = 86400;
        }
        
        // prepopulate the answers
        int length = (endTime-startTime) / frequencyDivisor;
        for(int i = 0; i <= length; i++)
        {
            toReturn.Add(0);
        }
        
        if(tweetFrequencies.ContainsKey(tweetName))
        {
            var relatedFreqs = tweetFrequencies[tweetName];
            foreach(var time in relatedFreqs)
            {
                if(time >= startTime && time <= endTime)
                {
                    // we found a valid time, now we need to calculate the associated interval
                    int interval = (time - startTime) / frequencyDivisor;
                    toReturn[interval] += 1;
                }
            }
        }
        
        return toReturn;
    }
}

public class TweetCounts2
{
    // get 3 dictionaries, one for min, hour day
    // the key would be the associated "frequency"
    // on input, we will calculate the "frequency" given the time for each min/hour/day and insert as required
    // repeat this for each tweetName
    // a master dictionary with string, dicts
    Dictionary<string, Frequencies> tweetFrequencies;

    public TweetCounts2() 
    {
        tweetFrequencies = new Dictionary<string, Frequencies>();
    }
    
    public void RecordTweet(string tweetName, int time) 
    {
        if(tweetFrequencies.ContainsKey(tweetName))
        {
            var freqs = tweetFrequencies[tweetName];
            freqs.AddRecord(time);
        }
        else
        {
            var freqs = new Frequencies();
            freqs.AddRecord(time);
            tweetFrequencies.Add(tweetName, freqs);
        }
        
    }
    
    public IList<int> GetTweetCountsPerFrequency(string freq, string tweetName, int startTime, int endTime) 
    {
        List<int> toReturn = null;
        if(tweetFrequencies.ContainsKey(tweetName))
        {
            var relatedFreqs = tweetFrequencies[tweetName];
            toReturn = relatedFreqs.GetRecords(freq, startTime, endTime);
        }
        
        return toReturn;
    }
}

public class Frequencies
{
    public Dictionary<int, int> minute;
    public Dictionary<int, int> hour;
    public Dictionary<int, int> day;
    
    public Frequencies()
    {
        minute = new Dictionary<int, int>();
        hour = new Dictionary<int, int>();
        day = new Dictionary<int, int>();
    }
    
    public void AddRecord(int time)
    {
        var min = time / 60;
        var hr = time / 3600;
        var d = time / 86400;
        
        // maintain minute count
        if(minute.ContainsKey(min))
        {
            minute[min] += 1;
        }
        else
        {
            minute.Add(min, 1);
        }
        
        // maintain hour count
        if(hour.ContainsKey(hr))
        {
            hour[hr] += 1;
        }
        else
        {
            hour.Add(hr, 1);
        }
        
        // maintain day count
        if(day.ContainsKey(d))
        {
            day[d] += 1;
        }
        else
        {
            day.Add(d, 1);
        }        
    }
    
    public List<int> GetRecords(string freq, int startTime, int endTime)
    {
        //Console.WriteLine($"freq:{freq}, startTime:{startTime}, endTime:{endTime}");
        int frequencyDivisor = 0;
        Dictionary<int, int> currentLookup = null;
            
        if(freq == "minute")
        {
            frequencyDivisor = 60;
            currentLookup = minute;
        }
        else if(freq == "hour")
        {
            frequencyDivisor = 3600;
            currentLookup = hour;
        }
        else if(freq == "day")
        {
            frequencyDivisor = 86400;
            currentLookup = day;
        }
        
        int startIndex = startTime / frequencyDivisor;
        int endIndex = endTime / frequencyDivisor;
        List<int> totalCounts = new List<int>();
        
        for(int i = startIndex; i <= endIndex; i++)
        {
            if(currentLookup.ContainsKey(i))
            {
                totalCounts.Add(currentLookup[i]);
            }
            else
            {
                totalCounts.Add(0);
            }
        }
        
        return totalCounts;
    }
    
    
}


/**
 * Your TweetCounts object will be instantiated and called as such:
 * TweetCounts obj = new TweetCounts();
 * obj.RecordTweet(tweetName,time);
 * IList<int> param_2 = obj.GetTweetCountsPerFrequency(freq,tweetName,startTime,endTime);
 */