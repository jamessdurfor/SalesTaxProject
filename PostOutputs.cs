namespace SalesTax
{
    internal class PostOutputs
    {
        public static void output(string[] items, double[] costs)
        {
            double itemSalesTax = 0;
            double itemImportTax = 0;
            double originalCost = 0;
            int numberOfItems = 1;
            int i = 0;
            double combinedItemCost = 0;
            double salesTaxTotal = 0;
            double importTaxTotal = 0;
            double total = 0;
            while (i < items.Length)
            {
                //This code is needed to make sure we display the correct item name
                //rather than including the number of items and the word "at" as part of it
                //we can't alter the actual item name because we'll need that to check to see
                //if various entries match up later on.
                //Also this version of the code won't work if you insist on inserting more than 9 of an item 
                //as the starting number.  If the requirements were more clear about that being necessary
                //I would have taken an approach where it was doable but it strikes me as feature
                //creep at the moment.
                string writtenItem = items[i].Substring(2);
                int stringLength = writtenItem.Length;
                writtenItem = writtenItem.Substring(0, stringLength - 3);
                originalCost = costs[i];
                //By setting the original Cost value here we can use it to properly
                //calculate the import tax later on rather than have the taxes compound on each other.
                bool salesTaxApplied = false;
                salesTaxApplied = TaxCalculator.isSalesTaxApplied(items[i]);

                if (salesTaxApplied == true)
                {
                    itemSalesTax = TaxCalculator.findSalesTax(costs[i]);
                    salesTaxTotal = salesTaxTotal + itemSalesTax;
                    costs[i] = costs[i] + itemSalesTax;
                }

                bool importTaxApplied = false;
                importTaxApplied = TaxCalculator.isImportTaxApplied(items[i]);

                if (importTaxApplied == true)
                {
                    itemImportTax = TaxCalculator.findImportTax(originalCost);
                    importTaxTotal = importTaxTotal + itemImportTax;
                    costs[i] = costs[i] + itemImportTax;
                }

                if (i < items.Length - 1)
                {
                    //I'm using nested if loops here rather than a && conjunction
                    //Because if it looks for items i+1 when its at the end of the 
                    //array it will cause the program to throw an error, so we do the
                    //check for the next item only if we've first confirmed there 
                    //is a next item to find.
                    if (items[i] != items[i + 1] && numberOfItems == 1)
                    {
                        //Since the desired output is to combine multiple
                        //entries with the same name into one singular entry, before
                        //we move onto the next entry first we need to see if that is the 
                        //case in this iteration of our while loop.
                        //In theory we could also do some code here to handle inputs where more than one
                        //item is purchased at a time, but that doesn't come up in any of the examples given so 
                        //I'm not going to bother coding it in.  There's covering obvious possibilities, and then there's
                        //feature creep, and writing all the code to deal with entries like "2 Books" strikes me as feature creep.
                        Console.WriteLine(writtenItem + ": " + "{0:0.00}", costs[i]);

                    }
                    //In theory this code could be more robust and designed to handle a situation
                    //where the same item are not entered one right after the other, but that never
                    //comes up on the inputs we're told to feed it in, so I considered doing so 
                    //feature creep at the moment.
                    else if (items[i] != items[i + 1] && numberOfItems > 1)
                    {
                        combinedItemCost = combinedItemCost + costs[i];
                        Console.WriteLine(writtenItem + ": " + "{0:0.00}", combinedItemCost + " (" + numberOfItems + " @ " + costs[i] + ")");
                        //While theoretically we could hard code in "2" for all the inputs we're given
                        //By making "numberOfItems" into a variable my code can handle situations where
                        //more than two items of the same name need to have their cost entries summed together
                        //and display accurate information to the user at the end of the process.
                        combinedItemCost = 0;
                        numberOfItems = 1;
                        //None of the presented entries have two different "groups of items" but by
                        //resetting the variables after we end the group we can make sure that we don't
                        //present incorrect information to the users when all is said and done.
                    }
                    else
                    {
                        //If we find the next item has the same name as the one coming up
                        //we'll add its cost to the total cost of the collection of items
                        //and increment how many items make up that collection.
                        combinedItemCost = combinedItemCost + costs[i];
                        numberOfItems = numberOfItems + 1;
                    }

                }
                else if (numberOfItems > 1)
                {
                    //This if else is needed to handle situations where the last entry in the list
                    //is part of a combined set of items, as is the case in the third set of items that 
                    //we're given to calculate the sales and import tax of.
                    combinedItemCost = combinedItemCost + costs[i];
                    string formattedCost = costs[i].ToString("0.00");
                    //The cost per item was not displaying properly using the same approach as before so it was
                    //necessary to create a properly formatted variable and use that instead to display it.
                    Console.WriteLine(writtenItem + ": " + "{0:0.00}", combinedItemCost + " (" + numberOfItems + " @ " + formattedCost + ")");
                    //We need to reset the number of items and combined item cost here to make sure that
                    //if more than one group of items is sent in, we it doesn't carry the cost from one group over
                    //to the next.
                    combinedItemCost = 0;
                    numberOfItems = 1;

                }
                else
                {
                    //Need to make sure to display the last item in the list.
                    Console.WriteLine(writtenItem + ": " + "{0:0.00}", +costs[i]);
                }
                total = total + costs[i];
                i = i + 1;
            }
            Console.WriteLine("Sales Taxes: " + "{0:0.00}", salesTaxTotal + importTaxTotal);
            Console.WriteLine("Total: " + "{0:0.00}", total);
        }
    }
}
