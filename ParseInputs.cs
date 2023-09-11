namespace SalesTax
{
    internal class ParseInputs
    {
        public static string[] parseItems(string itemEntries)
        {
            //Since you can't add items to an array individually in C# we'll use
            //a list temporarily, but convert it back to an array for ease of getting
            //the data we want out of it once it is done being created.
            List<string> itemList = new List<string>();
            bool finished = false;
            while (finished == false)
            {
                Nullable<int> endOfEntry = itemEntries.IndexOf(',');
                //If we haven't reached the final entry get the next one and only the next one in the
                //input string, if we've reached the last entry take everything that is left in the string as an entry.
                if (endOfEntry > 0)
                {
                    string nextEntry = itemEntries.Substring(0, endOfEntry.Value);
                    itemList.Add(nextEntry);
                    //We need to add one to the starting point of the substring so we'll
                    //have it begin after rather than on the comma.
                    //Likewise we need to make sure that the end point falls inside the string that
                    //we're passing so we need to remove one from the value, this is because of how we're
                    //comparing length against position in a string, with length starting from 1 while
                    //positions in a string start from zero.
                    itemEntries = itemEntries.Substring(endOfEntry.Value + 1, itemEntries.Length - endOfEntry.Value - 1);
                }
                else
                {
                    string nextEntry = itemEntries;
                    itemList.Add(nextEntry);
                    finished = true;
                }
            }
            string[] itemsFromUser = itemList.ToArray();
            return itemsFromUser;
        }

        //Sadly because we need different outputs one an array of strings and one an array of doubles
        //we can't use only one method to parse the information given to us.  Hence why the method
        //below is necessary.

        public static double[] parseCosts(string costEntries)
        {
            List<double> itemList = new List<double>();
            bool finished = false;
            while (finished == false)
            {
                Nullable<int> endOfEntry = costEntries.IndexOf(',');
                if (endOfEntry > 0)
                {
                    string nextEntry = costEntries.Substring(0, endOfEntry.Value);
                    double nextEntryDouble = Convert.ToDouble(nextEntry);
                    itemList.Add(nextEntryDouble);
                    costEntries = costEntries.Substring(endOfEntry.Value + 1, costEntries.Length - endOfEntry.Value - 1);
                }
                else
                {
                    string nextEntry = costEntries;
                    double nextEntryDouble = Convert.ToDouble(nextEntry);
                    itemList.Add(nextEntryDouble);
                    finished = true;
                }
            }
            double[] costsFromUser = itemList.ToArray();
            return costsFromUser;
        }
    }
}