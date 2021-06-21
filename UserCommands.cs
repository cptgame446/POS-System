using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSystem
{
    public class UserCommands
    {
        public static void SearchForItem(List<Item> inventory, List<User> personList)
        {
            string userInput = DataAggregation.GetInput("PLease enter an item name, or item SKU: ");
            bool isSKU = int.TryParse(userInput, out int sku);

            foreach (var item in inventory)
            {
                if (userInput == item.SKU || userInput == item.ItemName)
                {
                    item.DisplayProduct();
                    bool edit = DataAggregation.AddMore($"Would you like to modify {item.ItemName}? ");

                    if (edit)
                    {
                        Console.WriteLine("What would you like to edit?");
                        Console.Write("SKU, QUANTITY, COST: ");
                        string decision = Console.ReadLine();

                        if (decision.ToLower() == "quantity")
                        {
                            Item.EditQuantity(item);
                        }
                        else if (decision.ToLower() == "cost")
                        {
                            item.Cost = DataAggregation.MoneyConvert($"Please enter the cost of {item.ItemName}: $");
                        }
                        else if (decision.ToLower() == "sku")
                        {
                            item.ModifySku(inventory, personList);
                        }
                    }
                }
            }



        }
    }
}
