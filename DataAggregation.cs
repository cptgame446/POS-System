using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSystem
{
    public class DataAggregation
    {
        public static string GetInput(string message)
        {
            Console.Write(message);
            string output = Console.ReadLine();

            return output;
        }
        public static string GetInputCapital(string message)
        {
            Console.Write(message);
            string userInput = Console.ReadLine();
            string getCap = userInput.Substring(0, 1);
            string capital = getCap.ToUpper();
            string output = capital + userInput.Substring(1);

            return output.Substring(0);
        }
        public static bool AddMore(string message)
        {
            // continue yes or no?
            bool cont = false;
            bool valid = false;

            do
            {
                Console.Write(message);
                string decision = Console.ReadLine();
                if (decision.ToLower() == "yes" || decision.ToLower() == "y")
                {
                    cont = true;
                    valid = true;
                }
                else if (decision.ToLower() == "no" || decision.ToLower() == "n")
                {
                    cont = false;
                    valid = true;
                }
                else
                {
                    Console.WriteLine("What?  Please try again ");
                    
                } 

            } while (valid == false);

            return cont;
        }
        public static int IntConvert(string message)
        {
            bool success = false;
            int number = 0;
            do
            {
                string input = GetInput(message);
                success = int.TryParse(input, out number);
                if (!success)
                {
                    Console.WriteLine("You didn't enter a number!");
                }

            } while (success == false);

            return number;
        }
        public static decimal MoneyConvert(string message)
        {
            bool success = false;
            decimal number = 0;
            do
            {
                string input = GetInput(message);
                success = decimal.TryParse(input, out number);
                if (!success)
                {
                    Console.WriteLine("You didn't enter a number!");
                }

            } while (success == false);

            return number;
        }
        public static void DisplayInventory(List<Item> inventory)
        {
            int count = 0;
            foreach (var item in inventory)
            {
                count++;
                if (count >= 10)
                {
                    Console.WriteLine("Press enter to display more");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($"{item.ItemName}:");
                    Console.WriteLine($"Cost: ${item.Cost}, Stock: {item.StockQuantity}, SKU: {item.SKU}");
                    Console.WriteLine();
                    count = 0;
                }
                else
                {
                    Console.WriteLine($"{item.ItemName}:");
                    Console.WriteLine($"Cost: ${item.Cost}, Stock: {item.StockQuantity}, SKU: {item.SKU}");
                    Console.WriteLine();
                }
            }
        }

        public static void DisplayUsers(List<User> personList)
        {
            foreach (var person in personList)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}:");
                Console.WriteLine($"Email: {person.Email} Admin: {person.IsAdmin}");
                Console.WriteLine();
                Console.WriteLine("Press enter to continue...");
                
            }
            Console.ReadLine();
        }
        public static void BuildUser(List<User> personList)
        {
            bool addMore = true;

            do
            {
                Console.Clear();
                User user = new User();
                user.BuildUser(personList);

                if (user.ContinueBuild)
                {
                    personList.Add(user);
                }

                addMore = DataAggregation.AddMore("Would you like to add another item?  Y/N: ");

            } while (addMore);
        }
        public static void BuildUserList(List<User> personList)
        {
            bool addMore = true;
            do
            {
                Console.Clear();
                User user = new User();
                user.BuildUser(personList);

                addMore = DataAggregation.AddMore("Would you like to add another user? ");
                personList.Add(user);

            } while (addMore == true);
        }
        
        public static void BuildInventory(List<Item> inventory)
        {
            bool addMore = true;

            do
            {
                Console.Clear();
                Item item = new Item();
                item.BuildItem(inventory);

                if (item.ContinueBuild)
                {
                    inventory.Add(item);
                }

                addMore = DataAggregation.AddMore("Would you like to add another item?  Y/N: ");

            } while (addMore);
        }
        public static bool LengthCheck(int length, string whatToCheck)
        {
            bool output = false;

            if (length <= whatToCheck.Length)
            {
                output = true;
            }
            else
            {
                output = false;
                Console.WriteLine($"Sorry {whatToCheck} is not long enough, please try again.");
            }

            return output;
        }

        public static void SkuSearch(List<Item> inventory)
        {
            bool valid = false;
            do
            {
                string sku = DataAggregation.GetInput("Please enter the SKU: ");

                foreach (var product in inventory)
                {
                    if (sku == product.SKU)
                    {
                        product.DisplayProduct();
                        Console.WriteLine();
                        Console.WriteLine("Press enter to continue: ");
                        Console.ReadLine();
                    }
                }
            } while (valid);
        }


    }
}
