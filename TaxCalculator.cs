namespace SalesTax
{
    internal class TaxCalculator
    {
        public static double findSalesTax(double cost)
        {
            double salesTax = 0;
            salesTax = cost / 10;
            salesTax = Math.Ceiling(salesTax * 20) / 20;
            //Since we're asked to round to the nearest nickel this
            //code takes care of that, while the code below will 
            //make sure the correct number of variables are present in our 
            //answer.
            salesTax = Math.Round(salesTax, 2);
            return salesTax;
        }
        public static double findImportTax(double cost)
        {
            double importTax = 0;
            importTax = cost / 20;
            importTax = Math.Ceiling(importTax * 20) / 20;
            importTax = Math.Round(importTax, 2);
            return importTax;
        }

        public static bool isImportTaxApplied(string item)
        {
            item = item.ToUpper();
            //By using too upper can make sure that the code runs correctly
            //even if the user doesn't uppercase the word Imported like it is
            //in the examples.
            if (item.Contains("IMPORTED"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isSalesTaxApplied(string item)
        {
            item = item.ToUpper();
            //Cholates are uppercased when they're a bar, and lowercase
            //when they're in a box, using ToUpper lets us find them with fewer 
            //conditions required.  Also it can handle lower case inputs from the 
            //user.
            //That said, I'm not super proud of the dirty way that I'm doing this sorting, and instead would in a real world
            //situation ask the users for clarification on exactly how they want these items sorted, possibly
            //by turning them from just being strings into more complex variables that could have 
            //an "item type" and if that item type would be independent of the name, and thus make proper sorting of
            //if something gets hit with a sales tax or not much cleaner, but that's not possible in this particular situation
            //so instead here is code that will give the desired outputs based on the inputs supplied.
            if (item.Contains("BOOK") || item.Contains("MEDICINE") || item.Contains("PILL") || item.Contains("CHOCOLATE"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}