namespace SalesTax
{
    class SalesTaxSolution
    {
        static void Main(string[] args)
        {
            string[] items;
            double[] costs;
            string[] items2;
            double[] costs2;
            string[] items3;
            double[] costs3;
            //It's entirely possible to use a substring with a find location of "at" as part of the 
            //item name in order to instead just take the results in as a single input instead of, 
            //two separate ones, then split them up/handle them as needed, but since that wasn't
            //listed as part of the requirements, I'm going to keep them separate since that makes handling
            //the data easier.  Granted this creates code that will crash if the user will 
            //give more items than they do costs, but that sort of separation would strike me as feature
            //creep.

            Console.WriteLine("Do you want to run the baseline entries?  Only entering 'N' will not run them.");
            string results = Console.ReadLine();
            if (results != "N")
            {
                items = new string[] { "1 Book at", "1 Book at", "1 Music CD at", "1 Chocolate Bar at" };
                costs = new double[] { 12.49, 12.49, 14.99, 0.85 };
                items2 = new string[] { "1 Imported box of chocolates at", "1 Imported bottle of perfume at" };
                costs2 = new double[] { 10.00, 47.50 };
                items3 = new string[] { "1 Imported bottle of perfume at", "1 Bottle of perfume at", "1 Packet of headache pills at", "1 Imported box of chocolates at", "1 Imported box of chocolates at" };
                costs3 = new double[] { 27.99, 18.99, 9.75, 11.25, 11.25 };
                PostOutputs.output(items, costs);
                PostOutputs.output(items2, costs2);
                PostOutputs.output(items3, costs3);

            }
            else
            {
                //Instructions are as clear as possible because this code is somewhat fragile and it is easy to 
                //give inputs that fail/cause the code to throw errors.  If more direct instructions
                //had been given on what level of code ability to handle various inputs had been given
                //I would have focused on writing more robust code in this area.  As things stand it strikes
                //me as feature creep.
                Console.WriteLine("Type in the names of all items being purchased separated by a comma but no spaces.  Also make sure to add 'at' to the name of the item.  Example '1 Book at'");
                string itemEntries = Console.ReadLine();
                string[] itemsParsed = ParseInputs.parseItems(itemEntries);
                Console.WriteLine("Type in the costs of all items being purchased separated by a comma but no spaces.");
                string costEntries = Console.ReadLine();
                double[] costsParsed = ParseInputs.parseCosts(costEntries);
                PostOutputs.output(itemsParsed, costsParsed);
            }
        }
    }
}