using System;
using System.Collections.Generic;

namespace POSSystem
{
    public class Item
    {
        public string ItemName { get; set; }
        public int StockQuantity { get; set; }
        public string SKU { get; set; }
        public decimal Cost { get; set; }
        public int SKUcheck { get; set; }
        public bool ContinueBuild { get; set; } = true;



        public void DisplayProduct()
        {
            Console.WriteLine($"{ItemName}:");
            Console.WriteLine($"Cost: ${Cost}, Stock: {StockQuantity}, SKU: {SKU}");
        }
        public void SKUCheck(List<Item> inventory)
        {
            bool valid = false;
            do
            {
                valid = false;
                SKU = DataAggregation.GetInput("Please enter the SKU ");

                foreach (var product in inventory)
                {
                    if (SKU == product.SKU)
                    {
                        Console.WriteLine("Sorry, that SKU is already in use.  Please check and try again!");
                        valid = true;
                    }
                }
            } while (valid);
        }
        public void BuildItem(List<Item> inventory)
        {
            NameCheck(inventory);

            if (ContinueBuild == true)
            {
                StockQuantity = DataAggregation.IntConvert("Please enter the quantity in stock: ");

                Cost = DataAggregation.MoneyConvert($"Please enter the cost of {ItemName}: $");

                SKUCheck(inventory); 
            }
        }
        public void NameCheck(List<Item> inventory)
        {
            bool valid = false;
            do
            {
                valid = false;
                ItemName = DataAggregation.GetInputCapital("Pleaes enter the item name: ");

                foreach (var product in inventory)
                {
                    if (ItemName.ToLower() == product.ItemName.ToLower())
                    {
                        Console.WriteLine("You have already entered that into inventory.");

                        bool addMore = DataAggregation.AddMore($"Would you like to edit the quantity of {ItemName}? ");
                        if (addMore)
                        {
                            EditQuantity(product);
                            product.DisplayProduct();
                            ContinueBuild = false;

                        }
                        else
                        {
                            ContinueBuild = false;
                            break;
                        }

                    }
                }
            } while (valid);
        }
        public static void EditQuantity(Item product)
        {
            product.StockQuantity += DataAggregation.IntConvert("How many more did you want to add to stock? ");
        }
        public void ModifySku(List<Item> inventory, List<User> personList)
        {
            bool valid = false;
            string newSku;

            Console.WriteLine("SKU editing requires ADMIN privileges");
            string userName = DataAggregation.GetInput("Please enter your username: ");
            string currentUser = "";
            foreach (var user in personList)
            {
                if (userName == user.UserName)
                {
                    currentUser = user.UserName;
                    string userPassword = DataAggregation.GetInput($"Please enter the password for {user.UserName}: ");

                    if (userPassword == user.Password)
                    {
                        if (user.IsAdmin)
                        {
                            do
                            {
                                newSku = DataAggregation.GetInput("Please enter the new SKU: ");
                                foreach (var product in inventory)
                                {
                                    if (product.SKU == newSku)
                                    {
                                        Console.WriteLine($"That SKU is already in use for {product.ItemName}.  Please try again.");
                                        valid = false;
                                    }
                                    else
                                    {
                                        valid = true;
                                    }

                                }

                            } while (!valid);

                            SKU = newSku;
                        }
                        else
                        {
                            Console.WriteLine($"Sorry {user.FirstName}, you do not have Admin privileges");
                        }
                    }
                }
            }

           
        }
        public static void RemoveProduct(List<Item> inventory)
        {
            string userInput = DataAggregation.GetInput("Please enter the product name, or product SKU: ");

            foreach (var item in inventory)
            {
                if (userInput.ToLower() == item.ItemName.ToLower() || userInput.ToLower() == item.SKU)
                {
                    bool remove = DataAggregation.AddMore($"Are you sure you want to remove {item.ItemName}? ");

                    if (remove)
                    {
                        Console.WriteLine($"{item.ItemName} removed.");
                        inventory.Remove(item);
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        break;
                    }
                }
            }
        }
    }


}
