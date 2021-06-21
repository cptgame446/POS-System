//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace POSSystem
//{
//    class Inventory
//    {
//        public List<Item> InventoryItems { get; set; } = new List<Item>();

//        public string SkuCheck()
//        {
//            string output = "";
//            bool cont = false;

//            do
//            {
//                Console.Write("Please enter the SKU ");
//                string sku = Console.ReadLine();

//                foreach (var item in InventoryItems)
//                {
//                    if (item.SKU == output)
//                    {
//                        Console.WriteLine("That SKU already exists, please try again.");
//                        cont = true;
//                    }
//                    else
//                    {
//                        output = sku;
//                    }
//                } 

//            } while (cont);

//            return output;
            
//        }

//        public void CreateInventory()
//        {
//            string decision = "";

//            do
//            {
//                Item item = new Item();

//                Console.Write("Please enter the item name: ");
//                item.ItemName = Console.ReadLine();

//                Console.Write("Please enter the quantity in stock: ");
//                item.StockQuantity = DataAggregation.IntConvert();

//                Console.Write($"Please enter the cost of {item.ItemName}: $");
//                item.Cost = DataAggregation.NumberConvert();

//                //item.SKU = SkuCheck();
//                Console.Write("Please enter the SKU ");
//                item.SKU = Console.ReadLine();

//                InventoryItems.Add(item);

//                Console.Write("Would you like to add another? (Y/N): ");
//                decision = Console.ReadLine();

//                if (decision.ToLower() == "y")
//                {
//                    Console.Clear();
//                }


//            } while (decision.ToLower() == "y");
//        }
//    }
//}
