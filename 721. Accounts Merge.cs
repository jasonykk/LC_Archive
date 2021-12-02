public class Solution 
{
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) 
    {
        /*
        Need a way to mark emails with an account. Dictionary? Lookups are easy
        However, names are not unique. maybe a second dictionary with ID - name?
        
        Dictionary<int, string> ID - name
        Dictionary<int, string> ID - email
        
        For each email, check if the list of emails already exists, if so, this re-use existing ID.
        If not exists, create new entry in ID and enter all emails
        
        Once done iterating, we can go through the ID-email dict to create the final output
        
        Assuming all emails make up n, with unique users being m this will be O(m*n)
        
        Then we still need to sort the emails
        
        */
        
        Dictionary<Guid, string> idName = new Dictionary<Guid, string>();
        Dictionary<string, Guid> emailId = new Dictionary<string, Guid>();
        Dictionary<Guid, HashSet<string>> emailsLookup = new Dictionary<Guid, HashSet<string>>();
        List<IList<string>> toReturn = new List<IList<string>>();
        
        
        foreach(var emailList in accounts)
        {
            HashSet<Guid> idsToConsider = new HashSet<Guid>();
            for(int i = 1; i < emailList.Count; i++)
            {
                var currentEmail = emailList[i];
                if(emailId.ContainsKey(emailList[i]))
                {
                    idsToConsider.Add(emailId[emailList[i]]);
                }
            }
            
            // get a new ID if we didnt get one
            if(idsToConsider.Count == 0)
            {
                var tempId = Guid.NewGuid();
                idsToConsider.Add(tempId);
                idName.Add(tempId, emailList[0]);
                emailsLookup.Add(tempId, new HashSet<string>());
            }
                        
            // add all emails (if not yet exists).
            // only a single id, add as needed. it will only "loop" one time given only 1 id
            Guid id = Guid.Empty;
            foreach(var currentID in idsToConsider)
            {
                // unify any other emails we may have found
                if(id == Guid.Empty)
                {
                    id = currentID;
                }
                else
                {
                    // swap any old emails
                    if(emailsLookup.ContainsKey(currentID))
                    {
                        foreach(var email in emailsLookup[currentID])
                        {
                            emailsLookup[id].Add(email);
                            emailId.Remove(email);
                            emailId.Add(email, id);     
                        }
                        emailsLookup.Remove(currentID);
                        idName.Remove(currentID);
                    }
                }

                for(int i = 1; i < emailList.Count; i++)
                {
                    if(!emailId.ContainsKey(emailList[i]))
                    {
                        emailId.Add(emailList[i], id);
                        emailsLookup[id].Add(emailList[i]);
                    }
                    else
                    {
                        // update the associated ID
                        emailId.Remove(emailList[i]);
                        emailId.Add(emailList[i], id);                        
                        
                        // Add the current email
                        emailsLookup[id].Add(emailList[i]);
                    }
                }
            }
            
        }
        
        // at this point, all unique ids should have been saved 
        // O(m) if we have m unique user accounts
        foreach(var combination in idName)
        {
            var currentId = combination.Key;
            var currentName = combination.Value;
            // get all emails for this ID
            var uniqueEmails = emailsLookup[currentId];
            // sort it
            var currentEmails = uniqueEmails.ToList();
            currentEmails.Sort(StringComparer.Ordinal);
            // add the user name to the front O(n)
            currentEmails.Insert(0, currentName);
            toReturn.Add(currentEmails);
        }
        
        return toReturn;
    }
}