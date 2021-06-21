using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace POSSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> inventory = new List<Item>();
            List<User> personList = new List<User>();




            Console.WriteLine("Welcome, please press enter to conitnue...");
            Console.ReadLine();
            Console.Clear();

            ChooseFunction(inventory, personList);




            //string test = "hello";
            //string str = new String('*', test.Length);
            //Console.WriteLine(str);

            Console.ReadLine();
        }

        public static void ChooseFunction(List<Item> inventory, List<User> personList)
        {
            bool cont = true;
            do
            {
                Console.Clear();
                Console.WriteLine("|----------------------------|");
                Console.WriteLine("|Search product     'search' |");
                Console.WriteLine("|Remove product      'remove'|");
                Console.WriteLine("|Add Product           'add' |");
                Console.WriteLine("|List Inventory       'list' |");
                Console.WriteLine("|Create User        'create' |");
                Console.WriteLine("|Delete User        'delete' |");
                Console.WriteLine("|Show User            'user' |");
                Console.WriteLine("|Show users           'show' |");
                Console.WriteLine("|----------------------------|");
                Console.WriteLine();

                string decision = DataAggregation.GetInput("What would you you to do?: ");

                if (decision.ToLower() == "add")
                {
                    Console.Clear();
                    DataAggregation.BuildInventory(inventory);
                }
                else if (decision.ToLower() == "list")
                {
                    Console.Clear();
                    DataAggregation.DisplayInventory(inventory);
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                }
                else if (decision.ToLower() == "create")
                {
                    Console.Clear();
                    DataAggregation.BuildUser(personList);
                }
                else if (decision.ToLower() == "show")
                {
                    Console.Clear();
                    DataAggregation.DisplayUsers(personList);
                }
                else if (decision.ToLower() == "search")
                {
                    Console.Clear();
                    DataAggregation.SkuSearch(inventory);
                }
                else if (decision.ToLower() == "user")
                {
                    Console.Clear();
                    User.DisplayUser(personList);
                }
                else if (decision.ToLower() == "remove")
                {
                    Console.Clear();
                    Item.RemoveProduct(inventory);
                }

            } while (cont);
        }
    }
}
